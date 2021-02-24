using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Exo1
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        private static string apiKey = "86be9cea843de8454702fe1727d19b4d8716012a";
        static void Main(string[] args)
        {
            getContracts().Wait();
        }

        static async Task getContracts()
        {
            try
            {
                HttpResponseMessage res = await client.GetAsync("https://api.jcdecaux.com/vls/v1/contracts?apiKey=" + apiKey);
                res.EnsureSuccessStatusCode();

                string json = JsonSerializer.Serialize(res.Content.ReadAsStringAsync());
                Console.WriteLine("json : " + json.Replace("\\u0022", ""));
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            } 
        }
    }
}
