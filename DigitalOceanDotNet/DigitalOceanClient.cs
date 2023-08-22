using DigitalOceanDotNet.Clients;

namespace DigitalOceanDotNet
{
    public class DigitalOceanClient
    {
        public string Token { get; private set; }

        public DigitalOceanClient(string token)
        {
            Token = token;

            AccountClient = new AccountClient(token);
            RegionClient = new RegionClient(token);
            SshKey = new SshKeyClient(token);
        }

        public AccountClient AccountClient { get; private set; }
        public RegionClient RegionClient { get; private set; }
        public SshKeyClient SshKey { get; private set; }
    }
}
