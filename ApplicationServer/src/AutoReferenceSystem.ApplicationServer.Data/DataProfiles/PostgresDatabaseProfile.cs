using AutoReferenceSystem.ApplicationServer.Data.DataProfiles.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReferenceSystem.ApplicationServer.Data.DataProfiles
{
    public class PostgresDatabaseProfile : DataProfile
    {
        public string MigrationAssembly { get; set; }
        public PostgresDatabaseProfile(string name, string connectionString, bool useSeedData, bool migrateDatabase, bool createDatabase, string migrationAssembly) :
            base(name, connectionString, useSeedData, migrateDatabase, createDatabase)
        {
            MigrationAssembly = migrationAssembly;
        }

        public override void ConfigureDbContextOptionsBuilder(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql(ConnectionString, sql => sql.MigrationsAssembly(MigrationAssembly));
        }
    }
}
