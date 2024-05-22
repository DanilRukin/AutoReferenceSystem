using AutoReferenceSystem.ApplicationServer.Domain.Dtos;
using AutoReferenceSystem.ApplicationServer.SharedKernel.Results;
using AutoReferenceSystem.WebClient.Models;
using MediatR;
using System;


namespace AutoReferenceSystem.WebClient.Logic.Referencing.Queries
{
    internal class GetAnAbstractQuery : IRequest<Result<AbstractResultDto>>
    {
        public string SourceText { get; set; }
        public int ModelId { get; private set; }

        public AbstractionMethod AbstractionMethod { get; private set; }

        public AbstractVolume AbstractVolume { get; private set; }

        public AbsoluteAbstractVolumeMeasure Measure { get; private set; }

        public int WordCount { get; private set; }

        public int SentensiesCount { get; private set; }

        public double PercentsOfAbstract { get; private set; }

        public GetAnAbstractQuery(string sourceText, int modelId, AbstractionMethod abstractionMethod, AbstractVolume abstractVolume,
            AbsoluteAbstractVolumeMeasure measure, int wordCount, int sentensiesCount, double percentsOfAbstract)
        {
            SourceText = sourceText ?? throw new ArgumentNullException(nameof(sourceText));
            ModelId = modelId;
            AbstractionMethod = abstractionMethod;
            AbstractVolume = abstractVolume;
            Measure = measure;
            WordCount = wordCount;
            SentensiesCount = sentensiesCount;
            PercentsOfAbstract = percentsOfAbstract;
        }
    }
}
