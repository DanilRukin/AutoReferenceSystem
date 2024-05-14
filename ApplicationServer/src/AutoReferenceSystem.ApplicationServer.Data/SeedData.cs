using Microsoft.EntityFrameworkCore;


namespace AutoReferenceSystem.ApplicationServer.Data
{
    public static class SeedData
    {
        private static bool _empty = false;
        private static bool _created = false;
       


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

                context.SaveChanges();

                _empty = false;
            }
        }

        private static void ClearDatabase(AutoReferenceSystemContext context)
        {
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
