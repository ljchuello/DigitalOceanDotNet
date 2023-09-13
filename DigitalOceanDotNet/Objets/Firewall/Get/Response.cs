using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigitalOceanDotNet.Objets.Firewall.Get
{
    public class Response
    {
        [JsonProperty("firewalls")]
        public List<Firewall> Firewalls { get; set; } = new List<Firewall>();

        [JsonProperty("links")]
        public Universal.Links Links { get; set; } = new Universal.Links();

        [JsonProperty("meta")]
        public Universal.Meta Meta { get; set; } = new Universal.Meta();
    }
}
