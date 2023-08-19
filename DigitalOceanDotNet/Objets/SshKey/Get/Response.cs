using Newtonsoft.Json;
using System.Collections.Generic;

namespace DigitalOceanDotNet.Objets.SshKey.Get
{
    public class Response
    {
        [JsonProperty("ssh_keys")]
        public List<SshKey> SshKeys { get; set; } = new List<SshKey>();

        [JsonProperty("links")]
        public Universal.Links Links { get; set; } = new Universal.Links();

        [JsonProperty("meta")]
        public Universal.Meta Meta { get; set; } = new Universal.Meta();
    }
}
