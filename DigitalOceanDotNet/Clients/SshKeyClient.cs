using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using DigitalOceanDotNet.Objets.SshKey.Get;
using DigitalOceanDotNet.Objets.SshKey;

namespace DigitalOceanDotNet.Clients
{
    public class SshKeyClient
    {
        private readonly string _token = string.Empty;

        public SshKeyClient()
        {

        }

        public SshKeyClient(string token)
        {
            _token = token;
        }

        public async Task<List<SshKey>> Get()
        {
            List<SshKey> listSshKeys = new List<SshKey>();
            long page = 0;
            while (true)
            {
                // Nex
                page++;

                // Get list
                string json = await Core.SendGetRequest(_token, $"/account/keys?page={page}&per_page={Core.PerPage}");
                Response response = JsonConvert.DeserializeObject<Response>(json) ?? new Response();

                // Run
                foreach (SshKey row in response.SshKeys)
                {
                    listSshKeys.Add(row);
                }

                // Finish?
                if (string.IsNullOrEmpty(response.Links.Pages.Next))
                {
                    // Yes, finish
                    return listSshKeys;
                }
            }
        }

        public async Task<SshKeyClient> Get(long id)
        {
            // Get
            string json = await Core.SendGetRequest(_token, $"/account/keys/{id}");

            // Set
            JObject result = JObject.Parse(json);
            SshKeyClient response = JsonConvert.DeserializeObject<SshKeyClient>($"{result["ssh_key"]}") ?? new SshKeyClient();

            // Return
            return response;
        }

        public async Task<SshKey> Post(string name, string publicKey)
        {
            // Preparing raw
            string raw = $"{{ \"name\": \"{name}\", \"public_key\": \"{publicKey}\" }}";

            // Send post
            string json = await Core.SendPostRequest(_token, "/account/keys", raw);

            // Return
            JObject result = JObject.Parse(json);
            return JsonConvert.DeserializeObject<SshKey>($"{result["ssh_key"]}") ?? new SshKey();
        }

        public async Task<SshKey> Put(SshKey sshKey)
        {
            // Preparing raw
            string raw = $"{{\"name\":\"{sshKey.Name}\"}}";

            // Send post
            string jsonResponse = await Core.SendPutRequest(_token, $"/account/keys/{sshKey.Id}", raw);

            // Return
            JObject result = JObject.Parse(jsonResponse);
            return JsonConvert.DeserializeObject<SshKey>($"{result["ssh_key"]}") ?? new SshKey();
        }

        public async Task Delete(SshKey sshKey)
        {
            // Send post
            await Core.SendDeleteRequest(_token, $"/account/keys/{sshKey.Id}");
        }
    }
}
