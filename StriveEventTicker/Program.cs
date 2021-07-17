using GraphQL.Query.Builder;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Configuration;
using static StriveEventTicker.DataAccessors;

namespace StriveEventTicker
{
    class Program
    {
        private static HttpClient Client = new HttpClient();
        private static readonly string _token = ConfigurationManager.AppSettings["token"];
        private static readonly string _apiEndpoint = ConfigurationManager.ConnectionStrings["apiEndpoint"].ToString();

        static async Task Main(string[] args)
        {
            Uri requestUri = new Uri($"{_apiEndpoint}");

            Console.WriteLine(await GetEventsByTournamentStrive(Client, requestUri, _token));
        }
    }
}