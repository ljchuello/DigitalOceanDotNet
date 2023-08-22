using Newtonsoft.Json;

namespace DigitalOceanDotNet.Objets.Account
{
    public class Account
    {
        [JsonProperty("droplet_limit")]
        public long DropletLimit { get; set; } = 0;

        [JsonProperty("floating_ip_limit")]
        public long FloatingIpLimit { get; set; } = 0;

        [JsonProperty("reserved_ip_limit")]
        public long ReservedIpLimit { get; set; } = 0;

        [JsonProperty("volume_limit")]
        public long VolumeLimit { get; set; } = 0;

        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("uuid")]
        public string Uuid { get; set; } = string.Empty;

        [JsonProperty("email_verified")]
        public bool EmailVerified { get; set; } = false;

        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        [JsonProperty("status_message")]
        public string StatusMessage { get; set; } = string.Empty;

        [JsonProperty("team")]
        public Team Team { get; set; } = new Team();
    }

    public class Team
    {
        [JsonProperty("uuid")]
        public string Uuid { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;
    }
}
