using Kinopoisk.Domain.Core;
using System.Collections.Generic;
using System.Linq;

namespace Kinopoisk.Domain.Interfaces
{
    public interface IMovieRepository
    {
        
        Movie Like(int id);
        Movie Dislike(int id);
        Movie GetMovie(int id);

        IOrderedQueryable<Movie> GetMovieOrdered(int options);

    }
}
