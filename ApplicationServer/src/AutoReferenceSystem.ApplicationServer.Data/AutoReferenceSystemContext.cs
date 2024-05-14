using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoReferenceSystem.ApplicationServer.SharedKernel.Interfaces;

namespace AutoReferenceSystem.ApplicationServer.Data
{
    public class AutoReferenceSystemContext : DbContext
    {
        private IDomainEventDispatcher _domainEventDispatcher;
        public AutoReferenceSystemContext(IDomainEventDispatcher domainEventDispatcher, DbContextOptions<AutoReferenceSystemContext> options) : base(options)
        {
            _domainEventDispatcher = domainEventDispatcher;
        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            base.ConfigureConventions(builder);
            builder.Properties<DateTime>()
                .HaveConversion<Converters.DateTimeUtcConverter>();
        }

        public async Task SaveEntitiesAsync(CancellationToken cancellationToken)
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            var events = ChangeTracker.Entries<IDomainObject>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents.Any())
                .ToArray();
            await _domainEventDispatcher.DispatchAndClearEvents(events);
        }
    }
}
