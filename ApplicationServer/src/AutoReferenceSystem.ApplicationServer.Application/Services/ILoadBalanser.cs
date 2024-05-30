using AutoReferenceSystem.ApplicationServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReferenceSystem.ApplicationServer.Application.Services
{
    internal interface ILoadBalanser
    {
        Task<Server?> GetFreeModelServer(int modelId, CancellationToken cancellationToken = default);
    }
}
