using AutoReferenceSystem.ApplicationServer.Data.DataProfiles.Base;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoReferenceSystem.ApplicationServer.Data.DataProfiles
{
    public class DataProfileFactory : IDataProfileFactory
    {
        private IConfiguration _configuration;
        public DataProfileFactory(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public DataProfile CreateProfile()
        {
            string profileName = _configuration["UseProfile"];
            var section = _configuration.GetSection("Profiles");
            var profile = section.GetSection(profileName);
            string connectionString = profile[nameof(DataProfile.ConnectionString)];
            bool useSeedData = FromString(profile[nameof(DataProfile.UseSeedData)]);
            bool migrateDatabase = FromString(profile[nameof(DataProfile.MigrateDatabase)]);
            bool createDatabase = FromString(profile[nameof(DataProfile.CreateDatabase)]);
            if (profileName == "SqlServerProfile")
            {
                string migrationAssembly = profile[nameof(SqlServerDatabaseProfile.MigrationAssembly)];
                return new SqlServerDatabaseProfile(profileName, connectionString, useSeedData,
                    migrateDatabase, createDatabase, migrationAssembly);
            }
            else if (profileName == "PostgresProfile")
            {
                string migrationAssembly = profile[nameof(SqlServerDatabaseProfile.MigrationAssembly)];
                return new PostgresDatabaseProfile(profileName, connectionString, useSeedData,
                    migrateDatabase, createDatabase, migrationAssembly);
            }
            else if (profileName == "SQLiteProfile")
            {
                return new SQLiteDatabaseProfile(profileName, connectionString, useSeedData,
                    migrateDatabase, createDatabase);
            }
            else if (profileName == "InMemoryProfile")
            {
                return new InMemoryDatabaseProfile(profileName, connectionString, useSeedData,
                    migrateDatabase, createDatabase);
            }
            else
            {
                throw new InvalidOperationException($"Unable to create '{profileName}'" +
                    $" database profile");
            }
        }

        private bool FromString(string value) => value == "true" ? true : false;
    }
}
