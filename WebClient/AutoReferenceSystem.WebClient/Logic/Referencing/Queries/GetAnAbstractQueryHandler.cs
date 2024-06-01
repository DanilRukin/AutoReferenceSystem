using AutoReferenceSystem.ApplicationServer.Domain.Dtos;
using AutoReferenceSystem.ApplicationServer.SharedKernel.Results;
using AutoReferenceSystem.WebClient.Logic.Extensions;
using AutoReferenceSystem.WebClient.Models;
using MediatR;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace AutoReferenceSystem.WebClient.Logic.Referencing.Queries
{
    internal class GetAnAbstractQueryHandler : IRequestHandler<GetAnAbstractQuery, Result<LanguageModelResponseDto>>
    {
        private HttpClient _client;

        public GetAnAbstractQueryHandler(IHttpClientFactory factory)
        {
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));
            _client = factory.CreateClient();
        }

        public async Task<Result<LanguageModelResponseDto>> Handle(GetAnAbstractQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Result validationResult = Validate(request);
                if (validationResult.IsSuccess)
                {
                    bool isServerAlive = _client
                        .SendAsync(new HttpRequestMessage
                        {
                            Method = HttpMethod.Get,
                            RequestUri = new Uri(ApiHelper.GetRouteForHealthCheck(), UriKind.Relative)
                        })
                        .Result
                        .IsSuccessStatusCode;
                    if (isServerAlive)
                    {
                        HttpRequestMessage message = new HttpRequestMessage()
                        {
                            Method = HttpMethod.Put,
                            Content = JsonContent.Create(request.SourceText)
                        };
                        if (request.AbstractVolume == AbstractVolume.Absolute)
                        {
                            if (request.Measure == AbsoluteAbstractVolumeMeasure.WordsCount)
                            {
                                message.RequestUri = new Uri(ApiHelper
                                    .GetRouteForAnAbstractWithSpecifiedWordsCount(
                                        request.WordCount,
                                        request.UserId,
                                        request.ModelId,
                                        request.AbstractionMethod), UriKind.Relative);
                            }
                            else if (request.Measure == AbsoluteAbstractVolumeMeasure.SentenciesCount)
                            {
                                message.RequestUri = new Uri(ApiHelper
                                    .GetRouteForAnAbstractWithSpecifiedSentesiesCount(
                                        request.SentensiesCount,
                                        request.UserId,
                                        request.ModelId,
                                        request.AbstractionMethod), UriKind.Relative);
                            }
                        }
                        else if (request.AbstractVolume == AbstractVolume.Relative)
                        {
                            message.RequestUri = new Uri(ApiHelper
                                .GetRouteForAnAbstractByAbstractRelativeVolume(
                                    request.PercentsOfAbstract,
                                    request.UserId,
                                    request.ModelId,
                                    request.AbstractionMethod), UriKind.Relative);
                        }
                        var response = await _client.SendAsync(message, cancellationToken);
                        var result = await response
                            .Content
                            .ReadFromJsonAsync<LanguageModelResponseDto>(cancellationToken);
                        if (result == null)
                            return Result<LanguageModelResponseDto>.Error("Не удалось получить ответ от сервера");
                        return result;
                    }
                    else
                    {
                        return Result<LanguageModelResponseDto>.Error("Сервер недоступен");
                    }
                }
                else
                {
                    return Result<LanguageModelResponseDto>.Error(validationResult.Errors.AsOneString());
                }
            }
            catch (Exception ex)
            {
                return Result<LanguageModelResponseDto>.Error($"Что-то пошло не так. Причина: {ex.Message}");
            }
        }

        private Result Validate(GetAnAbstractQuery query)
        {
            if (string.IsNullOrWhiteSpace(query.SourceText))
            {
                return Result.Error("Введите хоть какой-нибудь текст или прикрепите файл!");
            }
            if (query.ModelId == 0)
            {
                return Result.Error("Выберите модель");
            }
            if (query.AbstractionMethod == AbstractionMethod.Unknown)
            {
                return Result.Error("Выберите метод реферирования");
            }
            if (query.AbstractVolume == AbstractVolume.Unknown)
            {
                return Result.Error("Укажите тип объема получаемого текста");
            }
            if (query.AbstractVolume == AbstractVolume.Absolute)
            {
                if (query.Measure == AbsoluteAbstractVolumeMeasure.None)
                {
                    return Result.Error("Необходимо указать меру абсолютного объема реферата");
                }
                else if (query.Measure == AbsoluteAbstractVolumeMeasure.WordsCount)
                {
                    if (query.WordCount < 1)
                    {
                        return Result.Error($"Неверное количество слов: {query.WordCount}");
                    }
                }
                else if (query.Measure == AbsoluteAbstractVolumeMeasure.SentenciesCount)
                {
                    if (query.SentensiesCount < 1)
                    {
                        return Result.Error($"Неверное количество предложений: {query.SentensiesCount}");
                    }
                }
                else
                {
                    return Result.Error("Неизвестная мера абсолютного объема");
                }
            }
            if (query.AbstractVolume == AbstractVolume.Relative)
            {
                if (query.PercentsOfAbstract <= 0 || query.PercentsOfAbstract > 100)
                {
                    return Result.Error($"Неверный относительный объем: {query.PercentsOfAbstract} %");
                }
            }
            return Result.Success();
        }
    }
}
