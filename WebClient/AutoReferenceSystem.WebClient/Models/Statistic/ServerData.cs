using System.Collections.Generic;


namespace AutoReferenceSystem.WebClient.Models.Statistic
{
    public class ServerData
    {
        public string Host { get; set; }

        public string Label { get; set; }

        public ICollection<string> Models { get; set; }
    }
}
