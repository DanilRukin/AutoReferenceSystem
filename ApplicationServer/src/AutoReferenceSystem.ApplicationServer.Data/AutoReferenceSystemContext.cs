using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoReferenceSystem.ApplicationServer.SharedKernel.Interfaces;
using AutoReferenceSystem.ApplicationServer.Domain.Entities;

namespace AutoReferenceSystem.ApplicationServer.Data
{
    public class AutoReferenceSystemContext : DbContext
    {
        private IDomainEventDispatcher _domainEventDispatcher;
        public AutoReferenceSystemContext(IDomainEventDispatcher domainEventDispatcher, DbContextOptions<AutoReferenceSystemContext> options) : base(options)
        {
            _domainEventDispatcher = domainEventDispatcher;
        }

        
        public DbSet<Attachment> Attachments { get; set; }

        public DbSet<AttachmentType> AttachmentTypes { get; set; }

        public DbSet<Characteristic> Characteristics { get; set; }

        public DbSet<ListValuesCharacteristic> ListValuesCharacteristics { get; set; }

        public DbSet<CharacteristicsType> CharacteristicsTypes { get; set; }

        public DbSet<Measure> Measures { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<ModelCharacteristic> ModelCharacteristics { get; set; }

        public DbSet<ReferencingQueryCharacteristic> ReferencingQueryCharacteristics { get; set; }

        public DbSet<ReferensingQuery> ReferensingQueries { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<Server> Servers { get; set; }


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
