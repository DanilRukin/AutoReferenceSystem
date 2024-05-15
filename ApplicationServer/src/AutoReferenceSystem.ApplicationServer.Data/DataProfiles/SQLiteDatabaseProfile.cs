using AutoReferenceSystem.ApplicationServer.Data.DataProfiles.Base;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;


namespace AutoReferenceSystem.ApplicationServer.Data.DataProfiles
{
    public class SQLiteDatabaseProfile : DataProfile
    {
        private SqliteConnection _connection;
        public SQLiteDatabaseProfile(string name, string connectionString, bool useSeedData, bool migrateDatabase, bool createDatabase) :
            base(name, connectionString, useSeedData, migrateDatabase, createDatabase)
        {
        }

        public override void ConfigureDbContextOptionsBuilder(DbContextOptionsBuilder builder)
        {
            _connection = new SqliteConnection(ConnectionString);
            _connection.Open();
            builder.UseSqlite(_connection);
        }
    }
}
