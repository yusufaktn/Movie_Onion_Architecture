using Application.Features.CQRS_DesignPattern.Queries.MovieQueries;
using Application.Features.CQRS_DesignPattern.Result.MovieResult;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS_DesignPattern.Handlers.MovieHandlers
{
    public class GetMovieByIdQueryHandler
    {
        private readonly MyContext _context;
        public GetMovieByIdQueryHandler(MyContext context)
        {
            _context = context;
        }


        public async Task<GetMovieByIdQueryResult> Handle(GetMovieByIdQuery result)
        {
            var value = await _context.Movies.FindAsync(result.MovieId);
            if (value == null)
                return null;

            return new GetMovieByIdQueryResult
            {
                adult = value.Adult,
                backdrop_path = value.CoverImageUrl,
                genre_ids = value.Genre_ids,
                id = value.MovieId,
                original_language = value.Original_language,
                original_title = value.Original_title,
                overview = value.Overview,
                popularity = value.Popularity,
                poster_path = value.Poster_path,
                release_date = value.Release_date,
                title = value.Title,
                video = false, 
                vote_average = value.Vote_average,
                vote_count = value.Vote_count
            };
        }


    }
}
