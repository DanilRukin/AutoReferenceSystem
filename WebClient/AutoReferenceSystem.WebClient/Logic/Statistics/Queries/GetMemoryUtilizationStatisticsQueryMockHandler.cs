using AntDesign;
using AutoReferenceSystem.ApplicationServer.SharedKernel.Results;
using AutoReferenceSystem.WebClient.Models.Statistic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AutoReferenceSystem.WebClient.Logic.Statistics.Queries
{
    public class GetMemoryUtilizationStatisticsQueryMockHandler : IRequestHandler<GetMemoryUtilizationStatisticsQuery, Result<List<MemoryUtilizationData>>>
    {
        public async Task<Result<List<MemoryUtilizationData>>> Handle(GetMemoryUtilizationStatisticsQuery request, CancellationToken cancellationToken)
        {
            await Task.Yield();
            int intervalCount = (int)((request.EndDate - request.StartDate).TotalMilliseconds / request.IntervalInMilliseconds);
            List<MemoryUtilizationData> result = new List<MemoryUtilizationData>();
            Random random = new Random();
            int interval = 0;
            for (int i = 0; i < intervalCount; i++)
            {
                result.Add(new MemoryUtilizationData() { AmountInBytes = random.Next(109645235, 945789623), Interval = interval });
                interval += request.IntervalInMilliseconds;
            }
            return result;
        }
    }
}
