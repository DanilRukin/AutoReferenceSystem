using System;

namespace AutoReferenceSystem.WebClient.Logic.Referencing
{
    internal static class ApiHelper
    {
        internal static string ServerBaseApiRoute => "api/referencing";
        internal static string GetRouteForAnAbstractByThesesCount(int count, Guid userId, int modelId)
            => $"/{ServerBaseApiRoute}/abstract/with_theses/{count}/{modelId}/{userId}";

        internal static string GetRouteForAnAbstractByAbstractRelativeVolume(double relativeVolume, Guid userId, int modelId)
            => $"/{ServerBaseApiRoute}/abstract/by_abstract_relative_volume/{relativeVolume}/{modelId}/{userId}";

        internal static string GetRouteForAnAbstractWithSpecifiedWordsCount(int count, Guid userId, int modelId)
            => $"/{ServerBaseApiRoute}/abstract/with_specified_words_count/{count}/{modelId}/{userId}";

        internal static string GetRouteForAnAbstractWithSpecifiedSentesiesCount(int count, Guid userId, int modelId)
            => $"/{ServerBaseApiRoute}/abstract/with_specified_sentesies_count/{count}/{modelId}/{userId}";

        internal static string GetRouteForHealthCheck() => $"/{ServerBaseApiRoute}/healthcheck";
    }
}
