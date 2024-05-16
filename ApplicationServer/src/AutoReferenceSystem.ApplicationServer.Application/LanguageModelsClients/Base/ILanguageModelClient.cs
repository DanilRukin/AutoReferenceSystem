using AutoReferenceSystem.ApplicationServer.Domain.Dtos;
using AutoReferenceSystem.ApplicationServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReferenceSystem.ApplicationServer.Application.LanguageModelsClients.Base
{
    public interface ILanguageModelClient
    {
        Task<LanguageModelResponseDto?> GetAnAbstract(Server server, int modelId);
    }
}
