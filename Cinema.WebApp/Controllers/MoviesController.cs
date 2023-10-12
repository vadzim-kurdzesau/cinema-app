using Cinema.WebApp.Models;
using Cinema.WebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.WebApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            var availableMovies = _movieService.GetAvailableMovies();
            return View(availableMovies);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var movie = _movieService.GetMovie(id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpGet("/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("/create")]
        public IActionResult Create(MovieViewModel movie)
        {
            _movieService.AddMovie(movie);
            return View(movie);
        }
    }
}
