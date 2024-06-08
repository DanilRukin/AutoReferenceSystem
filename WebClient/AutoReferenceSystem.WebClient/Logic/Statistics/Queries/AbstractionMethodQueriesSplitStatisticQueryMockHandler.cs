using AutoReferenceSystem.ApplicationServer.SharedKernel.Results;
using AutoReferenceSystem.WebClient.Models.Statistic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace AutoReferenceSystem.WebClient.Logic.Statistics.Queries
{
    public class AbstractionMethodQueriesSplitStatisticQueryMockHandler : IRequestHandler<AbstractionMethodQueriesSplitStatisticQuery, Result<List<AbstractionMethodQueriesSplitData>>>
    {
        public async Task<Result<List<AbstractionMethodQueriesSplitData>>> Handle(AbstractionMethodQueriesSplitStatisticQuery request, CancellationToken cancellationToken)
        {
            await Task.Yield();
            Random random = new();
            List<AbstractionMethodQueriesSplitData> result =
            [
                new() { AbstractionMethodName = "Abstraction", QueriesCount = random.Next(0, 500) },
                new() { AbstractionMethodName = "Extraction", QueriesCount = random.Next(0, 367) }
            ];
            return result;
        }
    }
}
