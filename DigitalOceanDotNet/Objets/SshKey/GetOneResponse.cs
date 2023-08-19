using Newtonsoft.Json;

namespace DigitalOceanDotNet.Objets.SshKey
{
    public class GetOneResponse
    {
        [JsonProperty("id")]
        public long Id { get; set; } = 0;

        [JsonProperty("public_key")]
        public string PublicKey { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("fingerprint")]
        public string Fingerprint { get; set; } = string.Empty;
    }
}
