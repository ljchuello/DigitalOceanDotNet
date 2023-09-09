using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigitalOceanDotNet.Objets.Snapshot.Get
{
    public class Response
    {
        [JsonProperty("snapshots")]
        public List<Snapshot> Snapshots { get; set; } = new List<Snapshot>();

        [JsonProperty("links")]
        public Universal.Links Links { get; set; } = new Universal.Links();

        [JsonProperty("meta")]
        public Universal.Meta Meta { get; set; } = new Universal.Meta();
    }
}
