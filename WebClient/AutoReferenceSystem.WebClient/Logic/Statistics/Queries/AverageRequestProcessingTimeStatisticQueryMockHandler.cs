using AutoReferenceSystem.ApplicationServer.SharedKernel.Results;
using AutoReferenceSystem.WebClient.Models.Statistic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AutoReferenceSystem.WebClient.Logic.Statistics.Queries
{
    public class AverageRequestProcessingTimeStatisticQueryMockHandler : IRequestHandler<AverageRequestProcessingTimeStatisticQuery, Result<List<AverageRequestProcessingTimeData>>>
    {
        public async Task<Result<List<AverageRequestProcessingTimeData>>> Handle(AverageRequestProcessingTimeStatisticQuery request, CancellationToken cancellationToken)
        {
            await Task.Yield();
            Random random = new Random();
            List<AverageRequestProcessingTimeData> result =
            [
                new() { AverageProcessingTimeInMilliseconds = random.Next(0, 100), ProcessingTimeType = "Обработка входных данных" },
                new() { AverageProcessingTimeInMilliseconds = random.Next(0, 1000), ProcessingTimeType = "Реферирование" },
                new() { AverageProcessingTimeInMilliseconds = random.Next(0, 20), ProcessingTimeType = "Вывод данных" },
            ];
            return result;
        }
    }
}
