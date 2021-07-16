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

            //var request = new HttpRequestMessage(HttpMethod.Post, requestUri);
            //request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            //var queryOptions = new QueryOptions() { Formatter = QueryFormatters.CamelCaseFormatter };

            //var query = new Query<PersonResponse>("query", queryOptions)
            //    .AddField<Person>(f => f.CurrentUser,
            //    sq => sq
            //        .AddField(f => f.Bio)
            //        .AddField(f => f.Birthday)
            //        .AddField(f => f.Id)
            //        );

            //Console.WriteLine(query.Build());

            //request.Content = new StringContent(JsonConvert.SerializeObject(new { query = query.Build()}));
            //request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //var response = await Client.SendAsync(request);

            //Console.WriteLine(await response.Content.ReadAsStringAsync());

            await GetEventsByTournamentStrive(Client, requestUri, _token);
        }
    }
}

class PersonResponse
{
    public Person CurrentUser { get; set; }
}

class Person
{
    public int Id { get; set; }
    public string Bio { get; set; }
    public string Birthday { get; set; }
}