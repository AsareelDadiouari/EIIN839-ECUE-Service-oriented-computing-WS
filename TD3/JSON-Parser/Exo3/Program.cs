using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Exo3
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        private static string apiKey = "86be9cea843de8454702fe1727d19b4d8716012a";
        static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                GetStationInfo(args[0], int.Parse(args[1])).Wait();
            }
            else
            {
                bool errorDetected;
                do
                {
                    try
                    {
                        Console.WriteLine("Entrer le nom du contract :");
                        string contractName = Console.ReadLine();
                        Console.WriteLine("Entrer le numéro de la station :");
                        int stationNumber = int.Parse(Console.ReadLine());

                        GetStationInfo(contractName, stationNumber).Wait();
                        errorDetected = false;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        errorDetected = true;
                    }
                } while (errorDetected);
            }
        }

        static async Task GetStationInfo(string contractName, int stationNumber)
        {
            HttpResponseMessage res = await client.GetAsync("https://api.jcdecaux.com/vls/v1/stations/" + stationNumber + "?contract=" + contractName + "&apiKey=" + apiKey);
            res.EnsureSuccessStatusCode();

            string json = JsonSerializer.Serialize(res.Content.ReadAsStringAsync());
            Console.WriteLine("json : " + json.Replace("\\u0022", ""));
        }

        static void GetStationNews(string[] stations, int stationNumber)
        {

        }
    }
}
