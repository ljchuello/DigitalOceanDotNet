using Newtonsoft.Json;
using System.Collections.Generic;

namespace DigitalOceanDotNet.Objets.Size
{
    public class Size
    {
        /// <summary>
        /// A human-readable string that is used to uniquely identify each size.
        /// </summary>
        [JsonProperty("slug")]
        public string Slug { get; set; } = string.Empty;

        /// <summary>
        /// The amount of RAM allocated to Droplets created of this size. The value is represented in megabytes.
        /// </summary>
        [JsonProperty("memory")]
        public long Memory { get; set; } = 0;

        /// <summary>
        /// The integer of number CPUs allocated to Droplets of this size.
        /// </summary>
        [JsonProperty("vcpus")]
        public long Vcpus { get; set; } = 0;

        /// <summary>
        /// The amount of disk space set aside for Droplets of this size. The value is represented in gigabytes.
        /// </summary>
        [JsonProperty("disk")]
        public long Disk { get; set; } = 0;

        /// <summary>
        /// The amount of transfer bandwidth that is available for Droplets created in this size. This only counts traffic on the public interface. The value is given in terabytes.
        /// </summary>
        [JsonProperty("transfer")]
        public double Transfer { get; set; } = 0;

        /// <summary>
        /// This attribute describes the monthly cost of this Droplet size if the Droplet is kept for an entire month. The value is measured in US dollars.
        /// </summary>
        [JsonProperty("price_monthly")]
        public double PriceMonthly { get; set; } = 0;

        /// <summary>
        /// This describes the price of the Droplet size as measured hourly. The value is measured in US dollars.
        /// </summary>
        [JsonProperty("price_hourly")]
        public double PriceHourly { get; set; } = 0;

        /// <summary>
        /// An array containing the region slugs where this size is available for Droplet creates.
        /// </summary>
        [JsonProperty("regions")]
        public List<string> Regions { get; set; } = new List<string>();

        /// <summary>
        /// This is a boolean value that represents whether new Droplets can be created with this size.
        /// </summary>
        [JsonProperty("available")]
        public bool Available { get; set; } = true;

        /// <summary>
        /// A string describing the class of Droplets created from this size. For example: Basic, General Purpose, CPU-Optimized, Memory-Optimized, or Storage-Optimized.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;
    }
}
