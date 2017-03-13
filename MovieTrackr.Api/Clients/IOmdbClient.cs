using System.Threading.Tasks;
using OMDB.Api.Adapter.Models;

namespace OMDB.Api.Adapter.Clients
{
    public interface IOmdbClient
    {
        Task<Movie> GetByName(string title);
        Movie GetByImdbId(string id);
    }
}
