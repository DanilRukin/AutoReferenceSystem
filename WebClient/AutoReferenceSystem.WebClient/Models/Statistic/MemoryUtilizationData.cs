using System.Text.Json.Serialization;

namespace AutoReferenceSystem.WebClient.Models.Statistic
{
    public class MemoryUtilizationData
    {
        [JsonPropertyName("amountInBytes")]
        public long AmountInBytes { get; set; }

        [JsonPropertyName("interval")]
        public int Interval { get; set; }
    }
}
