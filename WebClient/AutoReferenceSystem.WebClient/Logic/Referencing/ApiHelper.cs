using AutoReferenceSystem.ApplicationServer.Domain.Dtos;
using System;

namespace AutoReferenceSystem.WebClient.Logic.Referencing
{
    internal static class ApiHelper
    {
        internal static string ServerBaseApiRoute => "api/referencing";
        internal static string GetRouteForAnAbstractByThesesCount(int count, Guid userId, int modelId, AbstractionMethod abstractionMethod)
            => $"/{ServerBaseApiRoute}/abstract/with_theses/{count}/{modelId}/{GetAbstractionMethodName(abstractionMethod)}/{userId}";

        internal static string GetRouteForAnAbstractByAbstractRelativeVolume(double relativeVolume, Guid userId, int modelId, AbstractionMethod abstractionMethod)
            => $"/{ServerBaseApiRoute}/abstract/by_abstract_relative_volume/{relativeVolume}/{modelId}/{GetAbstractionMethodName(abstractionMethod)}/{userId}";

        internal static string GetRouteForAnAbstractWithSpecifiedWordsCount(int count, Guid userId, int modelId, AbstractionMethod abstractionMethod)
            => $"/{ServerBaseApiRoute}/abstract/with_specified_words_count/{count}/{modelId}/{GetAbstractionMethodName(abstractionMethod)}/{userId}";

        internal static string GetRouteForAnAbstractWithSpecifiedSentesiesCount(int count, Guid userId, int modelId, AbstractionMethod abstractionMethod)
            => $"/{ServerBaseApiRoute}/abstract/with_specified_sentesies_count/{count}/{modelId}/{GetAbstractionMethodName(abstractionMethod)}/{userId}";

        internal static string GetRouteForHealthCheck() => $"/{ServerBaseApiRoute}/healthcheck";

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
