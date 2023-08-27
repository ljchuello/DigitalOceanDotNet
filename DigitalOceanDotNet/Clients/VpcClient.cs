using DigitalOceanDotNet.Objets.SshKey;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using DigitalOceanDotNet.Objets.Vpc;
using System.Collections.Generic;
using DigitalOceanDotNet.Objets.Vpc.Get;

namespace DigitalOceanDotNet.Clients
{
    public class VpcClient
    {
        private readonly string _token;

        public VpcClient(string token)
        {
            _token = token;
        }

        public async Task<List<Vpc>> Get()
        {
            List<Vpc> list = new List<Vpc>();
            long page = 0;
            while (true)
            {
                // Nex
                page++;

                // Get list
                string json = await Core.SendGetRequest(_token, $"/vpcs?page={page}&per_page={Core.PerPage}");
                Response response = JsonConvert.DeserializeObject<Response>(json) ?? new Response();

                // Run
                foreach (Vpc row in response.Vpcs)
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

        public async Task<Vpc> Get(string id)
        {
            // Get
            string json = await Core.SendGetRequest(_token, $"/vpcs/{id}");

            // Set
            JObject result = JObject.Parse(json);
            Vpc response = JsonConvert.DeserializeObject<Vpc>($"{result["vpc"]}") ?? new Vpc();

            // Return
            return response;
        }
    }
}
