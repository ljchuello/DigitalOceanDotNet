using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOceanDotNet.Objets.Region;
using DigitalOceanDotNet.Objets.Region.Get;

namespace DigitalOceanDotNet.Clients
{
    public class RegionClient
    {
        private readonly string _token;

        public RegionClient(string token)
        {
            _token = token;
        }

        /// <summary>
        /// List All Data Center Regions
        /// </summary>
        /// <returns></returns>
        public async Task<List<Region>> Get()
        {
            List<Region> listRegion = new List<Region>();
            long page = 0;
            while (true)
            {
                // Nex
                page++;

                // Get list
                string json = await Core.SendGetRequest(_token, $"/regions?page={page}&per_page={Core.PerPage}");
                Response response = JsonConvert.DeserializeObject<Response>(json) ?? new Response();

                // Run
                foreach (Region row in response.Regions)
                {
                    listRegion.Add(row);
                }

                // Finish?
                if (string.IsNullOrEmpty(response.Links.Pages.Next))
                {
                    // Yes, finish
                    return listRegion;
                }
            }
        }
    }
}
