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
    public class GetAnAbstractQuery : IRequest<Result<AbstractResultDto>>
    {
        public string SourceText { get; private set; }
        public AbstractOptionsDto AbstractOptions { get; private set; }
        public Guid UserId { get; private set; }

        public GetAnAbstractQuery(string sourceText, AbstractOptionsDto abstractOptions, Guid userId)
        {
            SourceText = sourceText ?? throw new ArgumentNullException(nameof(sourceText));
            AbstractOptions = abstractOptions ?? throw new ArgumentNullException(nameof(abstractOptions));
            UserId = userId;
        }
    }
}
