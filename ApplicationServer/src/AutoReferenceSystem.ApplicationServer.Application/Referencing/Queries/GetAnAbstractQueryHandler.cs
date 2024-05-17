using AutoReferenceSystem.ApplicationServer.Application.LanguageModelsClients.Base;
using AutoReferenceSystem.ApplicationServer.Data;
using AutoReferenceSystem.ApplicationServer.Domain.Dtos;
using AutoReferenceSystem.ApplicationServer.Domain.Extensions.Dtos;
using AutoReferenceSystem.ApplicationServer.SharedKernel.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AutoReferenceSystem.ApplicationServer.Application.Referencing.Queries
{
    internal class GetAnAbstractQueryHandler : IRequestHandler<GetAnAbstractQuery, Result<AbstractResultDto>>
    {
        private AutoReferenceSystemContext _context;
        private ILanguageModelClient _languageModelClient;

        public GetAnAbstractQueryHandler(AutoReferenceSystemContext context, ILanguageModelClient languageModelClient)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _languageModelClient = languageModelClient ?? throw new ArgumentNullException(nameof(languageModelClient));
        }

        public async Task<Result<AbstractResultDto>> Handle(GetAnAbstractQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var servers = await _context
                    .Servers
                    .Join(_context.Models, s => s.Id, m => m.ServerId, (s, m) => s)
                    .ToListAsync(cancellationToken);
                if (servers.Count == 0)
                    return Result<AbstractResultDto>.Error($"Нет сервера, на котором развернута модель " +
                        $"(id модели = {request.AbstractOptions.ModelId})");
                // как-нибудь выбираем наименее нагруженный сервер
                var server = servers.First();
                var languageModelResponse = await _languageModelClient.GetAnAbstract(server, request.AbstractOptions.ModelId);
                if (languageModelResponse == null)
                    return Result<AbstractResultDto>.Error($"Не удалось получить ответ от языковой модели " +
                        $"(id модели = {request.AbstractOptions.ModelId})");
                return Result.Success(languageModelResponse.ToAbstractResultDto());
            }
            catch (Exception ex)
            {
                return ExceptionHandler.Handle<AbstractResultDto>(ex);
            }
        }
    }
}
