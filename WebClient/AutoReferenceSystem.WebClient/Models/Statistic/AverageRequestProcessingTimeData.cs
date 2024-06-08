using System.Text.Json.Serialization;

namespace AutoReferenceSystem.WebClient.Models.Statistic
{
    public class AverageRequestProcessingTimeData
    {
        [JsonPropertyName("averageProcessingTimeInMilliseconds")]
        public int AverageProcessingTimeInMilliseconds { get; set; }

        [JsonPropertyName("processingTimeType")]
        public string ProcessingTimeType { get; set; }
    }
}
