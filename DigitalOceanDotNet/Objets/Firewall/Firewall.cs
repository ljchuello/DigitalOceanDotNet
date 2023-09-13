using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace DigitalOceanDotNet.Objets.Firewall
{
    public class Firewall
    {
        /// <summary>
        /// A unique ID that can be used to identify and reference a firewall
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// A human-readable name for a firewall. The name must begin with an alphanumeric character. Subsequent characters must either be alphanumeric characters, a period (.), or a dash (-).
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// A status string indicating the current state of the firewall. This can be "waiting", "succeeded", or "failed".
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// 	
        /// Array of objects
        /// </summary>
        [JsonProperty("inbound_rules")]
        public List<InboundRule> InboundRules { get; set; } = new List<InboundRule>();

        /// <summary>
        /// Array of objects
        /// </summary>
        [JsonProperty("outbound_rules")]
        public List<OutboundRule> OutboundRules { get; set; } = new List<OutboundRule>();

        /// <summary>
        /// A time value given in ISO8601 combined date and time format that represents when the firewall was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; } = new DateTime(1900, 01, 01);

        /// <summary>
        /// An array containing the IDs of the Droplets assigned to the firewall.
        /// </summary>
        [JsonProperty("droplet_ids")]
        public List<long> DropletIds { get; set; } = new List<long>();

        [JsonProperty("tags")]
        public List<object> Tags { get; set; } = new List<object>();

        /// <summary>
        /// An array of objects each containing the fields "droplet_id", "removing", and "status". It is provided to detail exactly which Droplets are having their security policies updated. When empty, all changes have been successfully applied.
        /// </summary>
        [JsonProperty("pending_changes")]
        public List<object> PendingChanges { get; set; } = new List<object>();
    }

    public class Sources
    {
        [JsonProperty("addresses")]
        public List<string> Addresses { get; set; } = new List<string>();
    }

    public class InboundRule
    {
        /// <summary>
        /// The type of traffic to be allowed. This may be one of tcp, udp, or icmp.
        /// </summary>
        [JsonProperty("protocol")]
        public string Protocol { get; set; } = string.Empty;

        /// <summary>
        /// The ports on which traffic will be allowed specified as a string containing a single port, a range (e.g. "8000-9000"), or "0" when all ports are open for a protocol. For ICMP rules this parameter will always return "0".
        /// </summary>
        [JsonProperty("ports")]
        public string Ports { get; set; } = string.Empty;

        /// <summary>
        /// An object specifying locations from which inbound traffic will be accepted.
        /// </summary>
        [JsonProperty("sources")]
        public Sources Sources { get; set; } = new Sources();
    }

    public class Destinations
    {
        [JsonProperty("addresses")]
        public List<string> Addresses { get; set; } = new List<string>();
    }

    public class OutboundRule
    {
        /// <summary>
        /// The type of traffic to be allowed. This may be one of tcp, udp, or icmp.
        /// </summary>
        [JsonProperty("protocol")]
        public string Protocol { get; set; } = string.Empty;

        /// <summary>
        /// The ports on which traffic will be allowed specified as a string containing a single port, a range (e.g. "8000-9000"), or "0" when all ports are open for a protocol. For ICMP rules this parameter will always return "0".
        /// </summary>
        [JsonProperty("ports")]
        public string Ports { get; set; } = string.Empty;

        /// <summary>
        /// An object specifying locations to which outbound traffic that will be allowed.
        /// </summary>
        [JsonProperty("destinations")]
        public Destinations Destinations { get; set; } = new Destinations();
    }
}
