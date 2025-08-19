using Application.Interface;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class MovieRepository : GenericRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MyContext mycontext) : base(mycontext)
        {

        }

        public async Task<List<Movie>> GetMoviesByGenreAsync(List<int> genreId)
        {
            if (genreId == null || !genreId.Any())
            {
                return new List<Movie>();
            }

            var value = await _dbSet
                .Where(movie => movie.MovieGenres.Any(mg => genreId.Contains(mg.GenreId)))
                .ToListAsync();

            return value;

        }

    }
}
