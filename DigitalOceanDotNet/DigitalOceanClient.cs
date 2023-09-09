using DigitalOceanDotNet.Clients;

namespace DigitalOceanDotNet
{
    public class DigitalOceanClient
    {
        public string Token { get; private set; }

        public DigitalOceanClient(string token)
        {
            Token = token;

            Account = new AccountClient(token);
            Region = new RegionClient(token);
            Size = new SizeCliente(token);
            Snapshot = new SnapshotsClient(token);
            SshKey = new SshKeyClient(token);
            Vpc = new VpcClient(token);
        }

        public AccountClient Account { get; private set; }
        public RegionClient Region { get; private set; }
        public SizeCliente Size { get; private set; }
        public SnapshotsClient Snapshot { get; private set; }
        public SshKeyClient SshKey { get; private set; }
        public VpcClient Vpc { get; private set; }
    }
}
