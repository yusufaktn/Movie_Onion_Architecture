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

          return  value.Select(x=> new GetMovieQueryResult
          {
              MovieId = x.MovieId,
              CoverImageUrl = x.CoverImageUrl,
              Title = x.Title,
              Description = x.Description,
              CreatedYear = x.CreatedYear,
              Duration = x.Duration,
              Rating = x.Rating,
              ReleaseDate = x.ReleaseDate,
          }).ToList();



        }


    }
}
