using AutoReferenceSystem.ApplicationServer.SharedKernel.Results;
using AutoReferenceSystem.WebClient.Models.Statistic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AutoReferenceSystem.WebClient.Logic.Statistics.Queries
{
    public class GetCpuUtilizationStatisticsQueryMockHandler : IRequestHandler<GetCpuUtilizationStatisticsQuery, Result<List<CpuUtilizationData>>>
    {
        public async Task<Result<List<CpuUtilizationData>>> Handle(GetCpuUtilizationStatisticsQuery request, CancellationToken cancellationToken)
        {
            await Task.Yield();
            int intervalCount = (int)((request.EndDate - request.StartDate).TotalMilliseconds / request.IntervalInMilliseconds);
            List<CpuUtilizationData> result = new List<CpuUtilizationData>();
            Random random = new Random();
            int interval = 0;
            for (int i = 0; i < intervalCount; i++)
            {
                result.Add(new CpuUtilizationData() { CpuUtilization = Math.Round(random.NextDouble() * 100, 2), Interval = interval });
                interval += request.IntervalInMilliseconds;
            }
            return result;
        }
    }
}
