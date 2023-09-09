using Newtonsoft.Json;

namespace DigitalOceanDotNet.Objets.Account
{
    public class Account
    {
        /// <summary>
        /// The total number of Droplets current user or team may have active at one time.
        /// </summary>
        [JsonProperty("droplet_limit")]
        public long DropletLimit { get; set; } = 0;

        /// <summary>
        /// The total number of Floating IPs the current user or team may have.
        /// </summary>
        [JsonProperty("floating_ip_limit")]
        public long FloatingIpLimit { get; set; } = 0;

        [JsonProperty("reserved_ip_limit")]
        public long ReservedIpLimit { get; set; } = 0;

        [JsonProperty("volume_limit")]
        public long VolumeLimit { get; set; } = 0;

        /// <summary>
        /// The email address used by the current user to register for DigitalOcean.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// The display name for the current user.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The unique universal identifier for the current user.
        /// </summary>
        [JsonProperty("uuid")]
        public string Uuid { get; set; } = string.Empty;

        /// <summary>
        /// If true, the user has verified their account via email. False otherwise.
        /// </summary>
        [JsonProperty("email_verified")]
        public bool EmailVerified { get; set; } = false;

        /// <summary>
        /// <br>This value is one of "active", "warning" or "locked"</br>
        /// <br>Enum: "active" "warning" "locked"</br>
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// A human-readable message giving more details about the status of the account.
        /// </summary>
        [JsonProperty("status_message")]
        public string StatusMessage { get; set; } = string.Empty;

        /// <summary>
        /// When authorized in a team context, includes information about the current team.
        /// </summary>
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
