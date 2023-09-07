using Newtonsoft.Json;
using System.Collections.Generic;

namespace DigitalOceanDotNet.Objets.Region
{
    public class Region
    {
        /// <summary>
        /// The display name of the region. This will be a full name that is used in the control panel and other interfaces.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// A human-readable string that is used as a unique identifier for each region.
        /// </summary>
        [JsonProperty("slug")]
        public string Slug { get; set; } = string.Empty;

        /// <summary>
        /// This attribute is set to an array which contains features available in this region
        /// </summary>
        [JsonProperty("features")]
        public List<string> Features { get; set; } = new List<string>();

        /// <summary>
        /// This is a boolean value that represents whether new Droplets can be created in this region.
        /// </summary>
        [JsonProperty("available")]
        public bool Available { get; set; } = false;

        /// <summary>
        /// This attribute is set to an array which contains the identifying slugs for the sizes available in this region.
        /// </summary>
        [JsonProperty("sizes")]
        public List<string> Sizes { get; set; } = new List<string>();
    }
}
