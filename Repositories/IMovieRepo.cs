using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TKNoteApplication.Models;

namespace TKNoteApplication.Repositories
{
    public interface IMovieRepo
    {
        Movie FindMovieById(int id);

        IEnumerable<Movie> GetAllMovies();

        void SaveMovie(Movie note);

        void EditMovie(Movie note);

        void DeleteMovie(Movie note);
    }
}