using Newtonsoft.Json;

namespace DigitalOceanDotNet.Objets.SshKey
{
    public class SshKey
    {
        /// <summary>
        /// A unique identification number for this key. Can be used to embed a specific SSH key into a Droplet.
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; } = 0;

        /// <summary>
        /// The entire public key string that was uploaded. Embedded into the root user's authorized_keys file if you include this key during Droplet creation.
        /// </summary>
        [JsonProperty("public_key")]
        public string PublicKey { get; set; } = string.Empty;

        /// <summary>
        /// A human-readable display name for this key, used to easily identify the SSH keys when they are displayed.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// A unique identifier that differentiates this key from other keys using a format that SSH recognizes. The fingerprint is created when the key is added to your account.
        /// </summary>
        [JsonProperty("fingerprint")]
        public string Fingerprint { get; set; } = string.Empty;
    }
}
