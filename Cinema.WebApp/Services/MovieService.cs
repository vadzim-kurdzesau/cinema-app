using Cinema.Database;
using Cinema.Database.Entities;
using Cinema.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Cinema.WebApp.Services
{
    public class MovieService : IMovieService
    {
        private readonly CinemaDbContext _dbContext;

        public MovieService(CinemaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int AddMovie(MovieViewModel movie)
        {
            var newMovie = new MovieEntity
            {
                Title = movie.Title,
                Description = movie.Description,
                Lasts = TimeSpan.FromMinutes(movie.Lasts),
            };
            
            _dbContext.Movies.Add(newMovie);
            _dbContext.SaveChanges();

            return newMovie.Id;
        }

        public IEnumerable<AvailableMovieViewModel> GetAvailableMovies()
        {
            var movies = _dbContext.Movies.ToList();
            return movies.Select(movie => new AvailableMovieViewModel
            {
                Id = movie.Id,
                Title = movie.Title
            });
        }

        public MovieViewModel? GetMovie(int id)
        {
            var movie = _dbContext.Movies
                .Include(movie => movie.Sessions)
                .SingleOrDefault(movie => movie.Id == id);

            if (movie == null)
            {
                return null;
            }

            return new MovieViewModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Lasts = movie.Lasts.Minutes,
                Sessions = movie.Sessions.Any()
                    ? movie.Sessions.Select(session => new SessionViewModel
                    {
                        RoomName = session.HallName,
                        Starts = session.Starts,
                        Ends = session.Starts.Add(movie.Lasts)
                    })
                    : new List<SessionViewModel>
                    {
                        new SessionViewModel() { RoomName = "Room 1", Starts = DateTime.Now, Ends = DateTime.Now },
                        new SessionViewModel() { RoomName = "Room 2", Starts = DateTime.Now, Ends = DateTime.Now },
                        new SessionViewModel() { RoomName = "Room 3", Starts = DateTime.Now, Ends = DateTime.Now },
                        new SessionViewModel() { RoomName = "Room 4", Starts = DateTime.Now, Ends = DateTime.Now },
                        new SessionViewModel() { RoomName = "Room 5", Starts = DateTime.Now, Ends = DateTime.Now },
                        new SessionViewModel() { RoomName = "Room 1", Starts = DateTime.Now, Ends = DateTime.Now },
                        new SessionViewModel() { RoomName = "Room 2", Starts = DateTime.Now, Ends = DateTime.Now },
                        new SessionViewModel() { RoomName = "Room 3", Starts = DateTime.Now, Ends = DateTime.Now },
                        new SessionViewModel() { RoomName = "Room 4", Starts = DateTime.Now, Ends = DateTime.Now },
                        new SessionViewModel() { RoomName = "Room 5", Starts = DateTime.Now, Ends = DateTime.Now },
                    }
            };
        }
    }
}
