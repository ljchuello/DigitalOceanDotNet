using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using DigitalOceanDotNet.Objets.Account;

namespace DigitalOceanDotNet.Clients
{
    public class AccountClient
    {
        private readonly string _token;

        public AccountClient(string token)
        {
            _token = token;
        }

        /// <summary>
        /// To show information about the current user account
        /// </summary>
        /// <returns></returns>
        public async Task<Account> Get()
        {
            // Get
            string json = await Core.SendGetRequest(_token, $"/account");

            // Set
            JObject result = JObject.Parse(json);
            Account response = JsonConvert.DeserializeObject<Account>($"{result["account"]}") ?? new Account();

            // Return
            return response;
        }
    }
}
