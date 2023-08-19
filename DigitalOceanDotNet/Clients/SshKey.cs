using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace DigitalOceanDotNet.Clients
{
    public class SshKey : Objets.SshKey.GetOneResponse
    {
        private readonly string _token;

        public SshKey()
        {

        }

        public SshKey(string token)
        {
            _token = token;
        }

        public async Task<SshKey> Get(long id)
        {
            // Get
            string json = await Core.SendGetRequest(_token, "/account/keys/39143107");

            // Set
            JObject result = JObject.Parse(json);
            SshKey response = JsonConvert.DeserializeObject<SshKey>($"{result["ssh_key"]}") ?? new SshKey();

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
    }
}
