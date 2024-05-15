using AutoReferenceSystem.ApplicationServer.Data.DataProfiles.Base;
using Microsoft.EntityFrameworkCore;


namespace AutoReferenceSystem.ApplicationServer.Data.DataProfiles
{
    public class SqlServerDatabaseProfile : DataProfile
    {
        public string MigrationAssembly { get; private set; }
        public SqlServerDatabaseProfile(string name, string connectionString, bool useSeedData, bool migrateDatabase, bool createDatabase, string migrationAssembly) :
            base(name, connectionString, useSeedData, migrateDatabase, createDatabase)
        {
            MigrationAssembly = migrationAssembly;
        }

        public override void ConfigureDbContextOptionsBuilder(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(ConnectionString, sql => sql.MigrationsAssembly(MigrationAssembly));
        }
    }
}
