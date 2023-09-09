using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigitalOceanDotNet.Objets.Snapshot
{
    public class Snapshot
    {
        /// <summary>
        /// The unique identifier for the snapshot.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// A human-readable name for the snapshot.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// An array of the regions that the snapshot is available in. The regions are represented by their identifying slug values.
        /// </summary>
        [JsonProperty("regions")]
        public List<string> Regions { get; set; } = new List<string>();

        /// <summary>
        /// A time value given in ISO8601 combined date and time format that represents when the snapshot was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// The unique identifier for the resource that the snapshot originated from.
        /// </summary>
        [JsonProperty("resource_id")]
        public string ResourceId { get; set; } = string.Empty;

        /// <summary>
        /// The type of resource that the snapshot originated from.
        /// </summary>
        [JsonProperty("resource_type")]
        public string ResourceType { get; set; } = string.Empty;

        /// <summary>
        /// The minimum size in GB required for a volume or Droplet to use this snapshot.
        /// </summary>
        [JsonProperty("min_disk_size")]
        public long MinDiskSize { get; set; } = 0;

        /// <summary>
        /// The billable size of the snapshot in gigabytes.
        /// </summary>
        [JsonProperty("size_gigabytes")]
        public double SizeGigabytes { get; set; } = 0;
    }
}
