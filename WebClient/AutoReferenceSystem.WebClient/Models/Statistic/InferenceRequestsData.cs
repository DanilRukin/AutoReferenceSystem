using System;
using System.Text.Json.Serialization;

namespace AutoReferenceSystem.WebClient.Models.Statistic
{
    public class InferenceRequestsData
    {
        [JsonPropertyName("requestsCount")]
        public int RequestsCount { get; set; }

        [JsonPropertyName("checkDate")]
        public string CheckDate { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
