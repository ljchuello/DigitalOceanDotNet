using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using DigitalOceanDotNet.Objets.Vpc;
using System.Collections.Generic;
using DigitalOceanDotNet.Objets.Vpc.Get;
using DigitalOceanDotNet.Objets.SshKey;

namespace DigitalOceanDotNet.Clients
{
    public class VpcClient
    {
        private readonly string _token;

        public VpcClient(string token)
        {
            _token = token;
        }

        /// <summary>
        /// List All VPCs
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Retrieve an Existing VPC
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Create a New VPC
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="region"></param>
        /// <param name="ipRange"></param>
        /// <returns></returns>
        public async Task<Vpc> Post(string name, string description, string region, string ipRange)
        {
            // Preparing raw
            string raw = $"{{ \"name\": \"{name}\", \"description\": \"{description}\", \"region\": \"{region}\", \"ip_range\": \"{ipRange}\" }}";

            // Send post
            string json = await Core.SendPostRequest(_token, "/vpcs", raw);

            // Return
            JObject result = JObject.Parse(json);
            return JsonConvert.DeserializeObject<Vpc>($"{result["vpc"]}") ?? new Vpc();
        }

        /// <summary>
        /// To update information about a VPC
        /// </summary>
        /// <param name="vpc"></param>
        /// <returns></returns>
        public async Task<Vpc> Put(Vpc vpc)
        {
            // Preparing raw
            string raw = $"{{ \"name\": \"{vpc.Name}\", \"description\": \"{vpc.Description}\", \"default\": {(vpc.Default ? "true" : "false")} }}";

            // Send post
            string json = await Core.SendPutRequest(_token, $"/vpcs/{vpc.Id}", raw);

            // Return
            JObject result = JObject.Parse(json);
            return JsonConvert.DeserializeObject<Vpc>($"{result["vpc"]}") ?? new Vpc();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vpc"></param>
        /// <returns></returns>
        public async Task Delete(Vpc vpc)
        {
            // Send post
            await Core.SendDeleteRequest(_token, $"/vpcs/{vpc.Id}");
        }
    }
}
