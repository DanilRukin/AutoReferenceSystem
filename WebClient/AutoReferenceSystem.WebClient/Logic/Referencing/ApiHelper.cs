namespace AutoReferenceSystem.WebClient.Logic.Referencing
{
    public static class ApiHelper
    {
        public static string Api { get; set; } = "api/referencing";

        public static class Get
        {
            public static string AnAbstract(int modelId) 
                => $"{Api}/abstract?modelId={modelId}";
        }
    }
}
