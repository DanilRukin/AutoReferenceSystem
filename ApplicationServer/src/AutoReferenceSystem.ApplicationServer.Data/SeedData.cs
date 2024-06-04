using AutoReferenceSystem.ApplicationServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace AutoReferenceSystem.ApplicationServer.Data
{
    public static class SeedData
    {
        private static bool _empty = false;
        private static bool _created = false;
       
        
        public static User TestUser { get; private set; }

        public static Session TestUserSession { get; private set; }

        public static Model Bert { get; private set; }

        public static Model Llamma { get; private set; }

        public static ReferensingQuery TestReferensingQuery { get; private set; }

        public static Server TestServer { get; set; }

        public static void ApplyMigrationAndFillDatabase(AutoReferenceSystemContext context)
        {
            context.Database.Migrate();
            ClearDatabase(context);
            FillDatabase(context);
            _created = true;
        }

        public static void InitializeDatabase(AutoReferenceSystemContext context)
        {
            context.Database.EnsureCreated();
            ClearDatabase(context);
            FillDatabase(context);
            _created = true;
        }

        private static void FillDatabase(AutoReferenceSystemContext context)
        {
            if (_empty)
            {
                DateTime startDate = DateTime.Today;
                DateTime endDate = startDate.AddDays(1);

                TestUser = new User()
                {
                    FirstName = "Иванов",
                    LastName = "Иван",
                    Patronymic = "Иванович",
                    Login = "ivanov_ii",
                    Password = "password",
                    Id = Guid.Parse("ecfe7fc8-9c0a-4ac3-a970-e964be2afac1")
                };
                context.Users.Add(TestUser);
                context.SaveChanges();

                TestUserSession = new Session()
                {
                    Id = Guid.Parse("32af054e-4c67-4d8c-846e-7baa76adfc22"),
                    BeginDate = startDate,
                    EndDate = endDate,
                };
                context.Sessions.Add(TestUserSession);
                context.SaveChanges();

                Bert = new Model()
                {
                    Name = "BERT",
                };

                Llamma = new Model()
                {
                    Name = "LLaMMa"
                };

                context.Models.AddRange(Bert, Llamma);
                context.SaveChanges();

                TestReferensingQuery = new ReferensingQuery()
                {
                    Id = Guid.Parse("de7d0288-4528-4b36-8912-2f02f0850323"),
                    QueryNumber = 1,
                };
                context.ReferensingQueries.Add(TestReferensingQuery);
                context.SaveChanges();

                TestServer = new Server()
                {
                    Address = "192.168.1.123",
                    User = "guest",
                    UserPassword = "123",
                };

                context.Servers.Add(TestServer);
                context.SaveChanges();

                TestUser.Sessions?.Append(TestUserSession);

                TestUserSession.ReferensingQueries?.Append(TestReferensingQuery);

                Bert.ReferensingQueries?.Append(TestReferensingQuery);

                TestServer.Models.Append(Llamma);
                TestServer.Models.Append(Bert);

                context.SaveChanges();

                _empty = false;
            }
        }

        private static void ClearDatabase(AutoReferenceSystemContext context)
        {
            if (context.Users.Any())
                context.Users.RemoveRange(context.Users);
            if (context.Sessions.Any())
                context.Sessions.RemoveRange(context.Sessions);
            if (context.ReferensingQueries.Any())
                context.ReferensingQueries.RemoveRange(context.ReferensingQueries);
            if (context.Attachments.Any())
                context.Attachments.RemoveRange(context.Attachments);
            if (context.AttachmentTypes.Any())
                context.AttachmentTypes.RemoveRange(context.AttachmentTypes);
            if (context.Models.Any())
                context.Models.RemoveRange(context.Models);
            if (context.ModelCharacteristics.Any())
                context.ModelCharacteristics.RemoveRange(context.ModelCharacteristics);
            if (context.Measures.Any())
                context.Measures.RemoveRange(context.Measures);
            if (context.ListValuesCharacteristics.Any())
                context.ListValuesCharacteristics.RemoveRange(context.ListValuesCharacteristics);
            if (context.CharacteristicsTypes.Any())
                context.CharacteristicsTypes.RemoveRange(context.CharacteristicsTypes);
            if (context.ReferencingQueryCharacteristics.Any())
                context.ReferencingQueryCharacteristics.RemoveRange(context.ReferencingQueryCharacteristics);
            if (context.Characteristics.Any())
                context.Characteristics.RemoveRange(context.Characteristics);
            if (context.Servers.Any())
                context.Servers.RemoveRange(context.Servers);
            context.SaveChanges();
            _empty = true;
        }

        public static void ResetDatabase(AutoReferenceSystemContext context)
        {
            if (_created)
            {
                ClearDatabase(context);
                FillDatabase(context);
            }
        }
    }
}
