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

            return await GetResponse(requestUrl);

        }

        public async Task<Movie> GetByImdbId(string imdbId)
        {
            var requestUrl = new Uri(_omdbBaseUrl, string.Format(_byImdbIdResource, imdbId));

            return await GetResponse(requestUrl);
        }

        private async Task<Movie> GetResponse(Uri url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var movie = await response.Content.ReadAsAsync<Movie>();

                return movie;
            }
        }
    }
}