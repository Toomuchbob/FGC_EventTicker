using GraphQL.Query.Builder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace StriveEventTicker
{
    static class DataAccessors
    {
        public static async Task<string> GetEventsByTournamentStrive(HttpClient client, Uri endpoint, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var queryOptions = new QueryOptions() { Formatter = QueryFormatters.CamelCaseFormatter };

            // A dictionary of dictionaries is required for complex arguments

            // The filter and additional base query parameters need associated objects

            var filter = new Dictionary<string, object>();
            filter.Add("videogameIds", new int[] { 33945 });
            filter.Add("published", true);
            filter.Add("hasOnlineEvents", true);
            filter.Add("beforeDate", 1627698617);
            filter.Add("afterDate", 1625884217);

            var f = new Dictionary<string, object>();
            f.Add("perPage", 500);
            f.Add("page", 1);
            f.Add("filter", filter);

            var query = new Query<Tournaments>("tournaments", queryOptions)
                .AddArgument("query", f)
                .AddField(f => f.Nodes,
                sq => sq
                    .AddField(f => f.Id)
                );

            Console.WriteLine("{" + query.Build() + "}");

            request.Content = new StringContent(JsonConvert.SerializeObject(new { query = "{" + query.Build() + "}" }));
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }
    }
}

class Filter
{
    public int[] VideogameIds { get; set; }
    public bool Published { get; set; }
    public bool HasOnlineEvents { get; set; }
    public long BeforeDate { get; set; }
    public long AfterDate { get; set; }
}