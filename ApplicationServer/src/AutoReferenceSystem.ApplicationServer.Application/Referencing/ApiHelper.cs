using AutoReferenceSystem.ApplicationServer.Domain.Dtos;

namespace AutoReferenceSystem.ApplicationServer.Application.Referencing
{
    internal static class ApiHelper
    {
        internal static string ModelBaseApiRoute => "api/Model";
        internal static string GetRouteForAnAbstractByThesesCount(string serverAddress, int count, AbstractionMethod abstractionMethod) 
            => $"{serverAddress}/{ModelBaseApiRoute}/abstract/with_theses/{count}/{GetAbstractionMethodName(abstractionMethod)}";

        internal static string GetRouteForAnAbstractByAbstractRelativeVolume(string serverAddress, double relativeVolume, AbstractionMethod abstractionMethod) 
            => $"{serverAddress}/{ModelBaseApiRoute}/abstract/by_abstract_relative_volume/{relativeVolume}/{GetAbstractionMethodName(abstractionMethod)}";

        internal static string GetRouteForAnAbstractWithSpecifiedWordsCount(string serverAddress, int count, AbstractionMethod abstractionMethod) 
            => $"{serverAddress}/{ModelBaseApiRoute}/abstract/with_specified_words_count/{count}/{GetAbstractionMethodName(abstractionMethod)}";

        internal static string GetRouteForAnAbstractWithSpecifiedSentesiesCount(string serverAddress, int count, AbstractionMethod abstractionMethod) 
            => $"{serverAddress}/{ModelBaseApiRoute}/abstract/with_specified_sentesies_count/{count}/{GetAbstractionMethodName(abstractionMethod)}";

        internal static string GetRouteForHealthCheck(string serverAddress) => $"{serverAddress}/{ModelBaseApiRoute}/healthcheck";

        private static string GetAbstractionMethodName(AbstractionMethod abstractionMethod)
        {
            string result = nameof(AbstractionMethod.Unknown);
            string? name = Enum.GetName(typeof(AbstractionMethod), abstractionMethod);
            if (name is not null)
                result = name;
            return result.ToLower();
        }
    }
}
