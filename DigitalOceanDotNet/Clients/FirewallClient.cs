using DigitalOceanDotNet.Objets.Firewall;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOceanDotNet.Objets.Firewall.Get;

namespace DigitalOceanDotNet.Clients
{
    public class FirewallClient
    {
        private readonly string _token;

        public FirewallClient(string token)
        {
            _token = token;
        }

        /// <summary>
        /// To list all of the firewalls available on your account
        /// </summary>
        /// <returns></returns>
        public async Task<List<Firewall>> Get()
        {
            List<Firewall> list = new List<Firewall>();
            long page = 0;
            while (true)
            {
                // Nex
                page++;

                // Get list
                string json = await Core.SendGetRequest(_token, $"/firewalls?page={page}&per_page={Core.PerPage}");
                Response response = JsonConvert.DeserializeObject<Response>(json) ?? new Response();

                // Run
                foreach (Firewall row in response.Firewalls)
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
        /// To show information about an existing firewall
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Firewall> Get(string id)
        {
            // Get
            string json = await Core.SendGetRequest(_token, $"/firewalls/{id}");

            // Set
            JObject result = JObject.Parse(json);
            Firewall response = JsonConvert.DeserializeObject<Firewall>($"{result["firewall"]}") ?? new Firewall();

            // Return
            return response;
        }

        /// <summary>
        /// To create a new firewall
        /// </summary>
        /// <param name="name"></param>
        /// <param name="inboundRules"></param>
        /// <param name="outboundRules"></param>
        /// <returns></returns>
        public async Task<Firewall> Post(string name, List<InboundRule> inboundRules, List<OutboundRule> outboundRules)
        {
            // Preparing raw
            Firewall firewall = new Firewall();
            firewall.Name = name;
            firewall.InboundRules = inboundRules;
            firewall.OutboundRules = outboundRules;

            // To json
            string raw = JsonConvert.SerializeObject(firewall, Formatting.Indented);

            // Send
            string json = await Core.SendPostRequest(_token, "/firewalls", raw);

            // Return
            JObject result = JObject.Parse(json);
            return JsonConvert.DeserializeObject<Firewall>($"{result["firewall"]}") ?? new Firewall();
        }

        /// <summary>
        /// To update the configuration of an existing firewall
        /// </summary>
        /// <param name="firewall"></param>
        /// <returns></returns>
        public async Task<Firewall> Put(Firewall firewall)
        {
            // To json
            string raw = JsonConvert.SerializeObject(firewall, Formatting.Indented);

            // Send
            string json = await Core.SendPutRequest (_token, $"/firewalls/{firewall.Id}", raw);

            // Return
            JObject result = JObject.Parse(json);
            return JsonConvert.DeserializeObject<Firewall>($"{result["firewall"]}") ?? new Firewall();
        }

        /// <summary>
        /// To assign a Droplet to a firewall
        /// </summary>
        /// <param name="firewallId"></param>
        /// <param name="dropletIds"></param>
        /// <returns></returns>
        public async Task AddDropletToFirewall(string firewallId, List<long> dropletIds)
        {
            // To json
            string raw = $"{{ \"droplet_ids\": [{string.Join(", ", dropletIds)}] }}";

            // Send
            string json = await Core.SendPostRequest(_token, $"/firewalls/{firewallId}/droplets", raw);
        }

        /// <summary>
        /// To remove a Droplet from a firewall
        /// </summary>
        /// <param name="firewallId"></param>
        /// <param name="dropletIds"></param>
        /// <returns></returns>
        public async Task RemoveDropletToFirewall(string firewallId, List<long> dropletIds)
        {
            // To json
            string raw = $"{{ \"droplet_ids\": [{string.Join(", ", dropletIds)}] }}";

            // Send
            string json = await Core.SendDeleteRequest(_token, $"/firewalls/{firewallId}/droplets", raw);
        }

        /// <summary>
        /// To add additional access rules to a firewall
        /// </summary>
        /// <param name="firewallId"></param>
        /// <param name="inboundRules"></param>
        /// <param name="outboundRules"></param>
        /// <returns></returns>
        public async Task AddRulesToFirewall(string firewallId, List<InboundRule> inboundRules, List<OutboundRule> outboundRules)
        {
            // Set
            Firewall firewall = new Firewall();
            firewall.InboundRules = inboundRules;
            firewall.OutboundRules = outboundRules;

            // To json
            string raw = JsonConvert.SerializeObject(firewall, Formatting.Indented);

            // Send
            string json = await Core.SendPostRequest(_token, $"/firewalls/{firewallId}/rules", raw);
        }

        /// <summary>
        /// To remove access rules from a firewall
        /// </summary>
        /// <param name="firewallId"></param>
        /// <param name="inboundRules"></param>
        /// <param name="outboundRules"></param>
        /// <returns></returns>
        public async Task RemoveRulesToFirewall(string firewallId, List<InboundRule> inboundRules, List<OutboundRule> outboundRules)
        {
            // Set
            Firewall firewall = new Firewall();
            firewall.InboundRules = inboundRules;
            firewall.OutboundRules = outboundRules;

            // To json
            string raw = JsonConvert.SerializeObject(firewall, Formatting.Indented);

            // Send
            string json = await Core.SendDeleteRequest(_token, $"/firewalls/{firewallId}/rules", raw);
        }

        /// <summary>
        /// To delete a firewall
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(string id)
        {
            await Core.SendDeleteRequest(_token, $"/firewalls/{id}");
        }

        /// <summary>
        /// To delete a firewall
        /// </summary>
        /// <param name="firewall"></param>
        /// <returns></returns>
        public async Task Delete(Firewall firewall)
        {
            await Delete(firewall.Id);
        }
    }
}
