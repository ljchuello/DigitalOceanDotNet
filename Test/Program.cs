using DigitalOceanDotNet;
using DigitalOceanDotNet.Objets.Firewall;

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
            try
            {
                DigitalOceanClient digitalOceanClient = new DigitalOceanClient(await File.ReadAllTextAsync("D:\\DigitalOcean.api.txt"));
                
                Console.WriteLine("Finish");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Finish with error");
                Console.ReadLine();
            }
        }
    }
}