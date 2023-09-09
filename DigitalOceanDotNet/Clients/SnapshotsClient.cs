using DigitalOceanDotNet.Objets.Snapshot;
using DigitalOceanDotNet.Objets.Snapshot.Get;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalOceanDotNet.Clients
{
    public class SnapshotsClient
    {
        private readonly string _token;

        public SnapshotsClient(string token)
        {
            _token = token;
        }

        /// <summary>
        /// To list all of the snapshots available on your account
        /// </summary>
        /// <returns></returns>
        public async Task<List<Snapshot>> Get()
        {
            List<Snapshot> list = new List<Snapshot>();
            long page = 0;
            while (true)
            {
                // Nex
                page++;

                // Get list
                string json = await Core.SendGetRequest(_token, $"/snapshots?page={page}&per_page={Core.PerPage}");
                Response response = JsonConvert.DeserializeObject<Response>(json) ?? new Response();

                // Run
                foreach (Snapshot row in response.Snapshots)
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
        /// To retrieve information about a snapshot
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Snapshot> Get(string id)
        {
            // Get
            string json = await Core.SendGetRequest(_token, $"/snapshots/{id}");

            // Set
            JObject result = JObject.Parse(json);
            Snapshot response = JsonConvert.DeserializeObject<Snapshot>($"{result["snapshot"]}") ?? new Snapshot();

            // Return
            return response;
        }

        /// <summary>
        /// Delete a Snapshot
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(string id)
        {
            await Core.SendDeleteRequest(_token, $"/snapshots/{id}");
        }

        /// <summary>
        /// Delete a Snapshot
        /// </summary>
        /// <param name="snapshot"></param>
        /// <returns></returns>
        public async Task Delete(Snapshot snapshot)
        {
            await Delete(snapshot.Id);
        }
    }
}
