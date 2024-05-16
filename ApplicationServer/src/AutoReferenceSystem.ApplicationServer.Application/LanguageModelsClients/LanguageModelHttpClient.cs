using AutoReferenceSystem.ApplicationServer.Application.LanguageModelsClients.Base;
using AutoReferenceSystem.ApplicationServer.Domain.Dtos;
using AutoReferenceSystem.ApplicationServer.Domain.Entities;
using System.Net.Http.Json;


namespace AutoReferenceSystem.ApplicationServer.Application.LanguageModelsClients
{
    public class LanguageModelHttpClient : ILanguageModelClient
    {
        private readonly HttpClient _httpClient;

        public LanguageModelHttpClient(IHttpClientFactory factory)
        {
            if (factory == null) 
                throw new ArgumentNullException(nameof(factory));
            _httpClient = factory.CreateClient();
        }

        public async Task<LanguageModelResponseDto?> GetAnAbstract(Server server, int modelId)
        {
            LanguageModelResponseDto? result = await _httpClient
                .GetFromJsonAsync<LanguageModelResponseDto>(Get.Abstract(server.Address, modelId));
            return result;
        }

        private static class Get
        {
            public static string Abstract(string serverAddress, int idModel) => $"{serverAddress}?modelId={idModel}";
        }
    }
}
