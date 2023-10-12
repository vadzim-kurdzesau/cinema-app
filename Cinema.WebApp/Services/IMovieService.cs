using Cinema.Database.Entities;
using Cinema.WebApp.Models;

namespace Cinema.WebApp.Services
{
    public interface IMovieService
    {
        IEnumerable<AvailableMovieViewModel> GetAvailableMovies();

        MovieViewModel? GetMovie(int id);

        int AddMovie(MovieViewModel movie);
    }
}
