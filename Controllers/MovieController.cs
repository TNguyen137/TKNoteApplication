using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using TKNoteApplication.Models;
using TKNoteApplication.Repositories;

namespace TKMovieApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private const string ID = "{id}";
        private readonly IMovieRepo _movieRepository;

        public MovieController(IMovieRepo movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet(ID)]
        public ActionResult<Movie> GetMovie(int id)
        {
            var Movie = _movieRepository.FindMovieById(id);
            return Movie;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetMovies()
        {
            var Movies = _movieRepository.GetAllMovies().ToList();
            return Movies;
        }

        [HttpPost]
        public ActionResult<Movie> PostMovie(Movie Movie, String title, String genre, Decimal price, DateTime releaseDate)
        {
            if (releaseDate == null)
            {
                var currDate = DateTime.Now;
                Movie.ReleaseDate = currDate;
            }
            else
            {
                Movie.ReleaseDate = releaseDate;
            }
            Movie.Title = title;
            Movie.Genre = genre;
            Movie.Price = price;
            _movieRepository.SaveMovie(Movie);
            return Movie;
        }

        [HttpPut]
        public ActionResult<Movie> PutMovie(Movie Movie, String title, String genre, Decimal price)
        {
            Movie.Title = title;
            Movie.Genre = genre;
            Movie.Price = price;
            _movieRepository.EditMovie(Movie);
            return Movie;
        }

        [HttpDelete(ID)]
        public ActionResult<Movie> DeleteMovie(int id)
        {
            var Movie = _movieRepository.FindMovieById(id);
            _movieRepository.DeleteMovie(Movie);
            return Movie;
        }
    }
}
