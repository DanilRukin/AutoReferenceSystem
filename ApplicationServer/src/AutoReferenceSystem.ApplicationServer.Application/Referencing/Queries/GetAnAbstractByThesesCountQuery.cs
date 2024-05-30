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
    public class GetAnAbstractByThesesCountQuery : IRequest<Result<LanguageModelResponseDto>>
    {
        public int ModelId { get; private set; }

        public string SourceText { get; private set; }

        public int ThesesCount { get; private set; }

        public Guid UserId { get; private set; }

        public GetAnAbstractByThesesCountQuery(int modelId, string sourceText, int thesesCount, Guid userId)
        {
            ModelId = modelId;
            SourceText = sourceText ?? throw new ArgumentNullException(nameof(sourceText));
            ThesesCount = thesesCount;
            UserId = userId;
        }
    }
}
