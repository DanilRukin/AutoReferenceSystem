using AutoReferenceSystem.ApplicationServer.SharedKernel.Results;
using AutoReferenceSystem.WebClient.Models.Statistic;
using MediatR;
using System;
using System.Collections.Generic;

namespace AutoReferenceSystem.WebClient.Logic.Statistics.Queries
{
    public class GetGpuUtilizationStatisticsQuery : IRequest<Result<List<GpuUtilizationData>>>
    {
        public int ModelId { get; private set; }

        public int ServerId { get; private set; }

        public int IntervalInMilliseconds { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public GetGpuUtilizationStatisticsQuery(int modelId, int serverId, int intervalInMilliseconds, DateTime startDate, DateTime endDate)
        {
            ModelId = modelId;
            ServerId = serverId;
            IntervalInMilliseconds = intervalInMilliseconds;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
