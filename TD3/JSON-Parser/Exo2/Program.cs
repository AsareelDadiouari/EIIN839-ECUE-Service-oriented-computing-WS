using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Exo2
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        private static string apiKey = "86be9cea843de8454702fe1727d19b4d8716012a";
        static void Main(string[] args)
        {
            if(args.Length == 1)
            {
                GetStations(args[0]).Wait();
            } else
            {
                bool errorDetected;

                do
                {
                    try
                    {
                        Console.WriteLine("Entrer le nom du contract :");
                        string contractName = Console.ReadLine();

                        GetStations(contractName).Wait();
                        errorDetected = false;
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                        errorDetected = true;
                    }
                } while (errorDetected); 
            }
        }

        static async Task GetStations(string contractName)
        {
            HttpResponseMessage res = await client.GetAsync("https://api.jcdecaux.com/vls/v1/stations?contract=" + contractName + "&apiKey=" + apiKey);
            res.EnsureSuccessStatusCode();

            string json = JsonSerializer.Serialize(res.Content.ReadAsStringAsync());
            Console.WriteLine("json : " + json.Replace("\\u0022", ""));
        }
    }
}
