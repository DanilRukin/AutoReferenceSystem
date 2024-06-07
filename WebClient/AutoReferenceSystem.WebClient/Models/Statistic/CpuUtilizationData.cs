using System.Text.Json.Serialization;

namespace AutoReferenceSystem.WebClient.Models.Statistic
{
    public class CpuUtilizationData
    {
        [JsonPropertyName("cpuUtilization")]
        public double CpuUtilization { get; set; }

        [JsonPropertyName("interval")]
        public int Interval { get; set; }
    }
}
