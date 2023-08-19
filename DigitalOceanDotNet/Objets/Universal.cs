using Newtonsoft.Json;

namespace DigitalOceanDotNet.Objets
{
    public class Universal
    {
        public class Links
        {
            [JsonProperty("pages")]
            public Pages Pages { get; set; } = new Pages();
        }

        public class Meta
        {
            [JsonProperty("total")]
            public long Total { get; set; } = 0;
        }

        public class Pages
        {
            [JsonProperty("first")]
            public string First { get; set; } = string.Empty;

            [JsonProperty("prev")]
            public string Prev { get; set; } = string.Empty;

            [JsonProperty("last")]
            public string Last { get; set; } = string.Empty;

            [JsonProperty("next")]
            public string Next { get; set; } = string.Empty;
        }
    }
}
