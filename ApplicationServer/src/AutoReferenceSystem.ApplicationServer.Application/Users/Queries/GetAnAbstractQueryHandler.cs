using AutoReferenceSystem.ApplicationServer.Data;
using AutoReferenceSystem.ApplicationServer.Domain.Dtos;
using AutoReferenceSystem.ApplicationServer.SharedKernel.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReferenceSystem.ApplicationServer.Application.Users.Queries
{
    internal class GetAnAbstractQueryHandler : IRequestHandler<GetAnAbstractQuery, Result<AbstractResultDto>>
    {
        private AutoReferenceSystemContext _context;

        public GetAnAbstractQueryHandler(AutoReferenceSystemContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Result<AbstractResultDto>> Handle(GetAnAbstractQuery request, CancellationToken cancellationToken)
        {
            try
            {
                AbstractResultDto result = new();
                return Result.Success(result);
            }
            catch (Exception ex)
            {
                return ExceptionHandler.Handle<AbstractResultDto>(ex);
            }
        }
    }
}
