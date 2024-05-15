using AutoReferenceSystem.ApplicationServer.Data.DataProfiles.Base;
using Microsoft.EntityFrameworkCore;


namespace AutoReferenceSystem.ApplicationServer.Data.DataProfiles
{
    public class InMemoryDatabaseProfile : DataProfile
    {
        public InMemoryDatabaseProfile(string name, string connectionString, bool useSeedData, bool migrateDatabase, bool createDatabase) :
            base(name, connectionString, useSeedData, migrateDatabase, createDatabase)
        {
        }

        public override void ConfigureDbContextOptionsBuilder(DbContextOptionsBuilder builder)
        {
            builder.UseInMemoryDatabase(ConnectionString);
        }
    }
}
