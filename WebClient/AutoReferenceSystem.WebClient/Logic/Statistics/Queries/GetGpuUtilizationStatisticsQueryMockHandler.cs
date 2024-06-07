using AutoReferenceSystem.ApplicationServer.SharedKernel.Results;
using AutoReferenceSystem.WebClient.Models.Statistic;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AutoReferenceSystem.WebClient.Logic.Statistics.Queries
{
    public class GetGpuUtilizationStatisticsQueryMockHandler : IRequestHandler<GetGpuUtilizationStatisticsQuery, Result<List<GpuUtilizationData>>>
    {
        public async Task<Result<List<GpuUtilizationData>>> Handle(GetGpuUtilizationStatisticsQuery request, CancellationToken cancellationToken)
        {
            await Task.Yield();
            int intervalCount = (int)((request.EndDate - request.StartDate).TotalMilliseconds / request.IntervalInMilliseconds);
            List<GpuUtilizationData> result = new List<GpuUtilizationData>();
            Random random = new Random();
            int interval = 0;
            for (int i = 0; i < intervalCount; i++)
            {
                result.Add(new GpuUtilizationData() { GpuUtilization = Math.Round(random.NextDouble() * 100, 2), Interval = interval });
                interval += request.IntervalInMilliseconds;
            }
            return result;
        }
    }
}
