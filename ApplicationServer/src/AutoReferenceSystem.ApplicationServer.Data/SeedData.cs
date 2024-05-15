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

                TestUserSession = new Session()
                {
                    Id = Guid.Parse("32af054e-4c67-4d8c-846e-7baa76adfc22"),
                    BeginDate = startDate,
                    EndDate = endDate,
                };

                Bert = new Model()
                {
                    Id = 1,
                    Name = "BERT",
                };

                Llamma = new Model()
                {
                    Id = 2,
                    Name = "LLaMMa"
                };

                TestReferensingQuery = new ReferensingQuery()
                {
                    Id = Guid.Parse("de7d0288-4528-4b36-8912-2f02f0850323"),
                    QueryNumber = 1,
                };

                context.Users.Add(TestUser);
                context.Sessions.Add(TestUserSession);
                context.Models.AddRange(Bert, Llamma);
                context.ReferensingQueries.Add(TestReferensingQuery);

                TestUser.Sessions?.Append(TestUserSession);

                TestUserSession.User = TestUser;
                TestUserSession.UserId = TestUser.Id;
                TestUserSession.ReferensingQueries?.Append(TestReferensingQuery);

                TestReferensingQuery.Session = TestUserSession;
                TestReferensingQuery.SessionId = TestUserSession.Id;
                TestReferensingQuery.Model = Bert;
                TestReferensingQuery.ModelId = Bert.Id;

                Bert.ReferensingQueries?.Append(TestReferensingQuery);

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
