using System.Text.Json.Serialization;

namespace AutoReferenceSystem.WebClient.Models.Statistic
{
    public class AbstractionMethodQueriesSplitData
    {
        [JsonPropertyName("abstractionMethodName")]
        public string AbstractionMethodName { get; set; }

        [JsonPropertyName("queriesCount")]
        public int QueriesCount { get; set; }
    }
}
