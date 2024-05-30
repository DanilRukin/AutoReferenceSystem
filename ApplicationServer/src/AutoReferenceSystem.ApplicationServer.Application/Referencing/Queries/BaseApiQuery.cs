using AutoReferenceSystem.ApplicationServer.Application.Services;
using AutoReferenceSystem.ApplicationServer.Data;
using AutoReferenceSystem.ApplicationServer.Domain.Dtos;
using AutoReferenceSystem.ApplicationServer.SharedKernel.Results;
using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoReferenceSystem.ApplicationServer.Application.Referencing.Queries
{
    internal class BaseApiQuery
    {
        internal async Task<Result<LanguageModelResponseDto>> GetResponse<TQuery>(HttpClient client,
            Func<string, TQuery, string> routeConstructor, ILoadBalanser loadBalancer, string sourceText, int modelId, TQuery query,
            CancellationToken token)
        {
            try
            {
                var freeServer = await loadBalancer.GetFreeModelServer(modelId);
                if (freeServer == null)
                {
                    return Result<LanguageModelResponseDto>.NotFound($"Не найдено сервера для модели с id = '{modelId}'");
                }
                string route = routeConstructor.Invoke(freeServer.Address, query);
                HttpRequestMessage message = new HttpRequestMessage()
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri(route, UriKind.Absolute),
                    Content = JsonContent.Create(sourceText)
                };
                HttpResponseMessage response = await client.SendAsync(message, token);
                if (response.IsSuccessStatusCode)
                {
                    LanguageModelResponseDto? result = await response.Content.ReadFromJsonAsync<LanguageModelResponseDto>(token);
                    if (result == null)
                    {
                        return Result<LanguageModelResponseDto>.Error("Не удалось прочитать ответ с сервера");
                    }
                    return Result.Success(result);
                }
                else
                {
                    return Result<LanguageModelResponseDto>.Error($"Ошибка при получении ответа с сервера: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                return ExceptionHandler.Handle<LanguageModelResponseDto>(ex);
            }
        }
    }
}
