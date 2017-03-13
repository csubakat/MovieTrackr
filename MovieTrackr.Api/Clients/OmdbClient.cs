using System;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using OMDB.Api.Adapter.Models;

namespace OMDB.Api.Adapter.Clients
{
    public class OmdbClient : IOmdbClient
    {
        private readonly Uri _omdbBaseUrl = new Uri(ConfigurationManager.AppSettings["omdb:baseUrl"]);
        private string _byTitleResource = "?t={0}";
        private string _byImdbIdResource = "?i={0}";

        public async Task<Movie> GetByName(string title)
        {
            var requestUrl = new Uri(_omdbBaseUrl, string.Format(_byTitleResource, title));

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(requestUrl);
                response.EnsureSuccessStatusCode();

                var movie = await response.Content.ReadAsAsync<Movie>();

                return movie; //todo throw notfound
            }

        }

        public Movie GetByImdbId(string id)
        {
            throw new NotImplementedException();
        }
    }
}