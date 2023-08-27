using Newtonsoft.Json;
using System;

namespace DigitalOceanDotNet.Objets.Vpc
{
    public class Vpc
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("urn")]
        public string Urn { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty("region")]
        public string Region { get; set; } = string.Empty;

        [JsonProperty("ip_range")]
        public string IpRange { get; set; } = string.Empty;

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; } = new DateTime(1900, 01, 01);

        [JsonProperty("default")]
        public bool Default { get; set; } = false;
    }
}
