using Application.Features.CQRS_DesignPattern.Result.MovieResult;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS_DesignPattern.Handlers.MovieHandlers
{
    public class GetMovieQueryHandler
    {
        private MyContext _context;
        public GetMovieQueryHandler(MyContext context)
        {
            _context = context;
        }


        public async Task<List<GetMovieQueryResult>> Handle()
        {
            var value = await _context.Movies.ToListAsync();

            return value.Select(x => new GetMovieQueryResult
            {
                adult = x.Adult,
                backdrop_path = x.CoverImageUrl,
                id = x.MovieId,
                original_language = x.Original_language,
                original_title = x.Original_title,
                overview = x.Overview,
                popularity = x.Popularity,
                poster_path = x.Poster_path,
                release_date = x.Release_date,
                title = x.Title,
                vote_average = x.Vote_average,
                vote_count = x.Vote_count
            }).ToList();
        }


    }
}
