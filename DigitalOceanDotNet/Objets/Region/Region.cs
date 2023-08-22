using Newtonsoft.Json;
using System.Collections.Generic;

namespace DigitalOceanDotNet.Objets.Region
{
    public class Region
    {
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("slug")]
        public string Slug { get; set; } = string.Empty;

        [JsonProperty("features")]
        public List<string> Features { get; set; } = new List<string>();

        [JsonProperty("available")]
        public bool Available { get; set; } = false;

        [JsonProperty("sizes")]
        public List<string> Sizes { get; set; } = new List<string>();
    }
}
