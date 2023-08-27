using Newtonsoft.Json;
using System.Collections.Generic;

namespace DigitalOceanDotNet.Objets.Vpc.Get
{
    public class Response
    {
        [JsonProperty("vpcs")]
        public List<Vpc> Vpcs { get; set; } = new List<Vpc>();

        [JsonProperty("links")]
        public Universal.Links Links { get; set; } = new Universal.Links();

        [JsonProperty("meta")]
        public Universal.Meta Meta { get; set; } = new Universal.Meta();
    }
}
