using AutoReferenceSystem.ApplicationServer.Domain.Dtos;
using AutoReferenceSystem.ApplicationServer.SharedKernel.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReferenceSystem.ApplicationServer.Application.Referencing.Queries
{
    public class GetAnAbstractByAbstractRelativeVolumeQuery : IRequest<Result<LanguageModelResponseDto>>
    {
        public int ModelId { get; private set; }

        public string SourceText { get; private set; }

        public double RelativeVolume { get; private set; }

        public Guid UserId { get; private set; }

        public AbstractionMethod AbstractionMethod { get; private set; }

        public GetAnAbstractByAbstractRelativeVolumeQuery(int modelId, string sourceText, double relativeVolume,
            Guid userId, AbstractionMethod abstractionMethod)
        {
            ModelId = modelId;
            SourceText = sourceText ?? throw new ArgumentNullException(nameof(sourceText));
            RelativeVolume = relativeVolume;
            UserId = userId;
            AbstractionMethod = abstractionMethod;
        }
    }
}
