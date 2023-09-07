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

                foreach (var row in await digitalOceanClient.Vpc.Get())
                {
                    if (row.Default == false)
                    {
                        try
                        {
                            await digitalOceanClient.Vpc.Delete(row);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }

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