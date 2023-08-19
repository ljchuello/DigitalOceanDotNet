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
            DigitalOceanClient digitalOceanClient = new DigitalOceanClient(await File.ReadAllTextAsync("D:\\DigitalOcean.api.txt"));

            var temp = await digitalOceanClient.SshKey.Get();

            foreach (var row in temp)
            {
                row.Name = $"{Guid.NewGuid()}";
                await digitalOceanClient.SshKey.Put(row);
            }

            Console.WriteLine("xD");
            Console.ReadLine();
        }
    }
}