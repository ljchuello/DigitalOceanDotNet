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
        private readonly string _token;

        public SshKeyClient(string token)
        {
            _token = token;
        }

        /// <summary>
        /// To list all of the keys in your account
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// To get information about a key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SshKey> Get(long id)
        {
            // Get
            string json = await Core.SendGetRequest(_token, $"/account/keys/{id}");

            // Set
            JObject result = JObject.Parse(json);
            SshKey response = JsonConvert.DeserializeObject<SshKey>($"{result["ssh_key"]}") ?? new SshKey();

            // Return
            return response;
        }

        /// <summary>
        /// To add a new SSH public key to your DigitalOcean account
        /// </summary>
        /// <param name="name"></param>
        /// <param name="publicKey"></param>
        /// <returns></returns>
        public async Task<SshKey> Post(string name, string publicKey)
        {
            // Preparing raw
            string raw = $"{{ \"name\": \"{name}\", \"public_key\": \"{publicKey}\" }}";

            // Send
            string json = await Core.SendPostRequest(_token, "/account/keys", raw);

            // Return
            JObject result = JObject.Parse(json);
            return JsonConvert.DeserializeObject<SshKey>($"{result["ssh_key"]}") ?? new SshKey();
        }

        /// <summary>
        /// To update the name of an SSH key
        /// </summary>
        /// <param name="sshKey"></param>
        /// <returns></returns>
        public async Task<SshKey> Put(SshKey sshKey)
        {
            // Preparing raw
            string raw = $"{{\"name\":\"{sshKey.Name}\"}}";

            // Send
            string jsonResponse = await Core.SendPutRequest(_token, $"/account/keys/{sshKey.Id}", raw);

            // Return
            JObject result = JObject.Parse(jsonResponse);
            return JsonConvert.DeserializeObject<SshKey>($"{result["ssh_key"]}") ?? new SshKey();
        }

        /// <summary>
        /// To destroy a public SSH key that you have in your account
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(long id)
        {
            await Core.SendDeleteRequest(_token, $"/account/keys/{id}");
        }

        /// <summary>
        /// To destroy a public SSH key that you have in your account
        /// </summary>
        /// <param name="sshKey"></param>
        /// <returns></returns>
        public async Task Delete(SshKey sshKey)
        {
            await Delete(sshKey.Id);
        }
    }
}
