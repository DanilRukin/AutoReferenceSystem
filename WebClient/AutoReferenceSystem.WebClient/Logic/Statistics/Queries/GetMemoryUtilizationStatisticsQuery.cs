using AutoReferenceSystem.ApplicationServer.SharedKernel.Results;
using AutoReferenceSystem.WebClient.Models.Statistic;
using MediatR;
using System;
using System.Collections.Generic;

namespace AutoReferenceSystem.WebClient.Logic.Statistics.Queries
{
    public class GetMemoryUtilizationStatisticsQuery : IRequest<Result<List<MemoryUtilizationData>>>
    {
        public int ModelId { get; private set; }

        public int ServerId { get; private set; }

        public int IntervalInMilliseconds { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public GetMemoryUtilizationStatisticsQuery(int modelId, int serverId, int intervalInMilliseconds, DateTime startDate, DateTime endDate)
        {
            ModelId = modelId;
            ServerId = serverId;
            IntervalInMilliseconds = intervalInMilliseconds;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
