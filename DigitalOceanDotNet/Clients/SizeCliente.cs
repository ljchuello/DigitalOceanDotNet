using DigitalOceanDotNet.Objets.Size.Get;
using DigitalOceanDotNet.Objets.Size;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalOceanDotNet.Clients
{
    public class SizeCliente
    {
        private readonly string _token;

        public SizeCliente(string token)
        {
            _token = token;
        }

        /// <summary>
        /// To list all of available Droplet sizes
        /// </summary>
        /// <returns></returns>
        public async Task<List<Size>> Get()
        {
            List<Size> list = new List<Size>();
            long page = 0;
            while (true)
            {
                // Nex
                page++;

                // Get list
                string json = await Core.SendGetRequest(_token, $"/sizes?page={page}&per_page={Core.PerPage}");
                Response response = JsonConvert.DeserializeObject<Response>(json) ?? new Response();

                // Run
                foreach (Size row in response.Sizes)
                {
                    list.Add(row);
                }

                // Finish?
                if (string.IsNullOrEmpty(response.Links.Pages.Next))
                {
                    // Yes, finish
                    return list;
                }
            }
        }
    }
}
