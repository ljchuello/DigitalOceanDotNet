using Newtonsoft.Json;
using System.Collections.Generic;

namespace DigitalOceanDotNet.Objets.Size.Get
{
    public class Response
    {
        [JsonProperty("sizes")]
        public List<Size> Sizes { get; set; } = new List<Size>();

        [JsonProperty("links")]
        public Universal.Links Links { get; set; } = new Universal.Links();

        [JsonProperty("meta")]
        public Universal.Meta Meta { get; set; } = new Universal.Meta();
    }
}
