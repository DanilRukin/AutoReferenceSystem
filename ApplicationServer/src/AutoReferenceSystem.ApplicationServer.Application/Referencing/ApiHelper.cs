namespace AutoReferenceSystem.ApplicationServer.Application.Referencing
{
    internal static class ApiHelper
    {
        internal static string ModelBaseApiRoute => "api/Model";
        internal static string GetRouteForAnAbstractByThesesCount(string serverAddress, int count) 
            => $"{serverAddress}/{ModelBaseApiRoute}/abstract/with_theses/{count}";

        internal static string GetRouteForAnAbstractByAbstractRelativeVolume(string serverAddress, double relativeVolume) 
            => $"{serverAddress}/{ModelBaseApiRoute}/abstract/by_abstract_relative_volume/{relativeVolume}";

        internal static string GetRouteForAnAbstractWithSpecifiedWordsCount(string serverAddress, int count) 
            => $"{serverAddress}/{ModelBaseApiRoute}/abstract/with_specified_words_count/{count}";

        internal static string GetRouteForAnAbstractWithSpecifiedSentesiesCount(string serverAddress, int count) 
            => $"{serverAddress}/{ModelBaseApiRoute}/abstract/with_specified_sentesies_count/{count}";

        internal static string GetRouteForHealthCheck(string serverAddress) => $"{serverAddress}/{ModelBaseApiRoute}/healthcheck";
    }
}
