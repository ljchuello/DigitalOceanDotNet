using DigitalOceanDotNet;
using DigitalOceanDotNet.Clients;
using Newtonsoft.Json;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
        }

        static async Task MainAsync()
        {
            DigitalOceanClient digitalOceanCliente = new DigitalOceanClient("dop_v1_c96240155cf0d2fad877c9b1322c9a337ad76eb13ae72faa97f629a6398cd93e");

            //SshKey sshKey = await digitalOceanCliente.SshKey.Get(39143107);

            try
            {
                for (int i = 1; i <= 150; i++)
                {
                    var keygen = new SshKeyGenerator.SshKeyGenerator(2048);
                    var privateKey = keygen.ToPrivateKey();
                    var publicSshKey = keygen.ToRfcPublicKey();

                    Console.WriteLine($"{i:n0}");
                    var a = await digitalOceanCliente.SshKey.Post($"{Guid.NewGuid()}", publicSshKey);
                    Console.WriteLine($"{a.Name} | {a.PublicKey}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.ReadLine();
        }
    }
}