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

            return new GetMovieByIdQueryResult
            {
                MovieId = value.MovieId,
                CoverImageUrl = value.CoverImageUrl,
                CreatedYear = value.CreatedYear,
                Description = value.Description,
                Duration = value.Duration,
                Rating = value.Rating,
                ReleaseDate = value.ReleaseDate,
                Title = value.Title

            };

        } 


    }
}
