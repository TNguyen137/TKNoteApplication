using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TKNoteApplication.Database;
using TKNoteApplication.Models;

namespace TKNoteApplication.Repositories.Implementations
{
    public class MovieRepo : IMovieRepo
    {
        private MovieDbContext _context;

        public MovieRepo(MovieDbContext context)
        {
            _context = context;
        }

        public Movie FindMovieById(int id)
        {
            var movie = _context.Movies.Find(id);
            return movie;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            var movies = _context.Movies;
            return movies;
        }

        public void SaveMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void EditMovie(Movie movie)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
        }

        public void DeleteMovie(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}
