using System;
using System.Threading.Tasks;
using System.Web.Http;
using OMDB.Api.Adapter.Clients;

namespace OMDB.Api.Adapter.Controllers
{
    [RoutePrefix("api/movie")]
    public class MovieController : ApiController
    {
        private OmdbClient _omdbClient;

        public MovieController()
        {
            _omdbClient = new OmdbClient();
        }

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
    }
}

