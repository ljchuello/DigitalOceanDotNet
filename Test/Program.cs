using DigitalOceanDotNet;

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

                var a = await digitalOceanClient.Vpc.Get();

                Console.WriteLine("xD");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
            }
        }
    }
}