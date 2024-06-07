using System.Text.Json.Serialization;

namespace AutoReferenceSystem.WebClient.Models.Statistic
{
    public class GpuUtilizationData
    {
        [JsonPropertyName("gpuUtilization")]
        public double GpuUtilization { get; set; }

        [JsonPropertyName("interval")]
        public int Interval { get; set; }
    }
}
