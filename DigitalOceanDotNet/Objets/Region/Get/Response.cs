using Newtonsoft.Json;
using System.Collections.Generic;

namespace DigitalOceanDotNet.Objets.Region.Get
{
    public class Response
    {
        [JsonProperty("regions")]
        public List<Region> Regions { get; set; } = new List<Region>();

        [JsonProperty("links")]
        public Universal.Links Links { get; set; } = new Universal.Links();

        [JsonProperty("meta")]
        public Universal.Meta Meta { get; set; } = new Universal.Meta();
    }
}
