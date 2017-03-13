using System;
using System.Threading.Tasks;
using System.Web.Http;
using OMDB.Api.Adapter.Clients;

namespace OMDB.Api.Adapter.Controllers
{
    [RoutePrefix("api/movie")]
    public class MovieController : ApiController
    {
        private readonly IOmdbClient _omdbClient;

        public MovieController(IOmdbClient omdbClient)
        {
            _omdbClient = omdbClient;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetByTitle([FromUri] string title)
        {
            try
            {
                var response = await _omdbClient.GetByName(title);

                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetByImdbId([FromUri] string imdbId)
        {
            try
            {
                var response = await _omdbClient.GetByImdbId(imdbId);

                return Ok(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

