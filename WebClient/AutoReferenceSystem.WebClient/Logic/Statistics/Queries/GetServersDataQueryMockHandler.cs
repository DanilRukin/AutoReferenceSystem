using AutoReferenceSystem.ApplicationServer.SharedKernel.Results;
using AutoReferenceSystem.WebClient.Models.Statistic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AutoReferenceSystem.WebClient.Logic.Statistics.Queries
{
    public class GetServersDataQueryMockHandler : IRequestHandler<GetServersDataQuery, Result<List<ServerData>>>
    {
        public async Task<Result<List<ServerData>>> Handle(GetServersDataQuery request, CancellationToken cancellationToken)
        {
            await Task.Yield();
            int serversCount = 25;
            List<ServerData> servers = new List<ServerData>();
            Random random = new();
            for (int i = 0; i < serversCount; i++)
            {
                List<ModelData> models = new List<ModelData>();
                int modelsCount = random.Next(1, 4);
                for (int j = 0; j < modelsCount; j++)
                {
                    models.Add(new ModelData() { Id = random.Next(), Name = _modelsNames[random.Next(0, _modelsNames.Length - 1)] });
                }
                servers.Add(new ServerData()
                {
                    Host = $"10.81.3.{i + 1}",
                    Label = i / 3 == 1 ? "production" : "test",
                    Models = models
                });
            }
            return Result.Success(servers);
        }

        private string[] _modelsNames = new string[]
        {
            "Llama 3 13b",
            "Llama 3 70b",
            "Llama 3 8b",
            "Llama 3 7b",
            "BERT 12b",
            "BERT 24b",
            "BERT 8b",
            "FastText",
        };
    }
}
