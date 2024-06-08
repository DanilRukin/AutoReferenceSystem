using AutoReferenceSystem.ApplicationServer.SharedKernel.Results;
using AutoReferenceSystem.WebClient.Models.Statistic;
using MediatR;
using System;
using System.Collections.Generic;

namespace AutoReferenceSystem.WebClient.Logic.Statistics.Queries
{
    public class AverageRequestProcessingTimeStatisticQuery : IRequest<Result<List<AverageRequestProcessingTimeData>>>
    {
        public int ModelId { get; private set; }

        public int ServerId { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public AverageRequestProcessingTimeStatisticQuery(int modelId, int serverId, DateTime startDate, DateTime endDate)
        {
            ModelId = modelId;
            ServerId = serverId;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
