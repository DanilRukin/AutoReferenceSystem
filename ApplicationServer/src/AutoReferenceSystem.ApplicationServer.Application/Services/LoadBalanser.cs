using AutoReferenceSystem.ApplicationServer.Data;
using AutoReferenceSystem.ApplicationServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoReferenceSystem.ApplicationServer.Application.Services
{
    internal class LoadBalanser : ILoadBalanser
    {
        private AutoReferenceSystemContext _context;

        public LoadBalanser(AutoReferenceSystemContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Server?> GetFreeModelServer(int modelId, CancellationToken cancellationToken = default)
        {
            //var servers = await _context
            //    .Servers
            //    .Join(_context.Models, s => s.Id, m => m.ServerId, (s, m) => s)
            //    .ToListAsync(cancellationToken);
            var servers = await _context
                .Servers
                .Include(s => s.Models)
                .ToListAsync();
            var s = servers.Where(s => s.Models.FirstOrDefault(m => m.Id == modelId).ServerId == s.Id).FirstOrDefault();
            return s;
        }
    }
}
