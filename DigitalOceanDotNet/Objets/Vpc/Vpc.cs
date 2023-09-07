using Newtonsoft.Json;
using System;

namespace DigitalOceanDotNet.Objets.Vpc
{
    public class Vpc
    {
        /// <summary>
        /// A unique ID that can be used to identify and reference the VPC.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// The uniform resource name (URN) for the resource in the format do:resource_type:resource_id.
        /// </summary>
        [JsonProperty("urn")]
        public string Urn { get; set; } = string.Empty;

        /// <summary>
        /// The name of the VPC. Must be unique and may only contain alphanumeric characters, dashes, and periods.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// A free-form text field for describing the VPC's purpose. It may be a maximum of 255 characters.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The slug identifier for the region where the VPC will be created.
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; } = string.Empty;

        /// <summary>
        /// The range of IP addresses in the VPC in CIDR notation. Network ranges cannot overlap with other networks in the same account and must be in range of private addresses as defined in RFC1918. It may not be smaller than /28 nor larger than /16. If no IP range is specified, a /20 network range is generated that won't conflict with other VPC networks in your account.
        /// </summary>
        [JsonProperty("ip_range")]
        public string IpRange { get; set; } = string.Empty;

        /// <summary>
        /// A time value given in ISO8601 combined date and time format.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; } = new DateTime(1900, 01, 01);

        /// <summary>
        /// A boolean value indicating whether or not the VPC is the default network for the region. All applicable resources are placed into the default VPC network unless otherwise specified during their creation. The default field cannot be unset from true. If you want to set a new default VPC network, update the default field of another VPC network in the same region. The previous network's default field will be set to false when a new default VPC has been defined.
        /// </summary>
        [JsonProperty("default")]
        public bool Default { get; set; } = false;
    }
}
