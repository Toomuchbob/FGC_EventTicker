using GraphQL.Query.Builder;
using Newtonsoft.Json;
using System;
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

            var query = new Query<PersonResponse>("query", queryOptions)
                .AddField<Person>(f => f.CurrentUser,
                sq => sq
                    .AddField(f => f.Bio)
                    .AddField(f => f.Birthday)
                    .AddField(f => f.Id)
                    );

            Console.WriteLine(query.Build());

            request.Content = new StringContent(JsonConvert.SerializeObject(new { query = query.Build() }));
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
