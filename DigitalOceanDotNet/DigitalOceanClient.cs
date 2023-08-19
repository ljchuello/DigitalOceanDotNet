using DigitalOceanDotNet.Clients;

namespace DigitalOceanDotNet
{
    public class DigitalOceanClient
    {
        public string Token { get; private set; }

        public DigitalOceanClient(string token)
        {
            Token = token;

            SshKey = new SshKey(token);
        }

        public SshKey SshKey { get; private set; }
    }
}
