using AntDesign;
using AutoReferenceSystem.ApplicationServer.SharedKernel.Results;
using AutoReferenceSystem.WebClient.Models.Statistic;
using MediatR;
using System;
using System.Collections.Generic;

namespace AutoReferenceSystem.WebClient.Logic.Statistics.Queries
{
    public class AbstractionMethodQueriesSplitStatisticQuery : IRequest<Result<List<AbstractionMethodQueriesSplitData>>>
    {
        public int ModelId { get; private set; }

        public int ServerId { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public AbstractionMethodQueriesSplitStatisticQuery(int modelId, int serverId, DateTime startDate, DateTime endDate)
        {
            ModelId = modelId;
            ServerId = serverId;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
