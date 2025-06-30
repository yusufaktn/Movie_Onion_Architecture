using Application.Features.CQRS_DesignPattern.Command.MovieCommand;
using Domain.Entity;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS_DesignPattern.Handlers.MovieHandlers
{
    public class CreateMovieCommadnHandler
    {
        private MyContext _context;
        public CreateMovieCommadnHandler(MyContext context)
        {
            _context = context;
        }

        public async void Handle(CreateMovieCommand createMovieCommand)
        {
            _context.Movies.Add(new Movie
            {
                CoverImageUrl = createMovieCommand.CoverImageUrl,
                CreatedYear = createMovieCommand.CreatedYear,
                Description = createMovieCommand.Description,
                Duration = createMovieCommand.Duration,
                Rating = createMovieCommand.Rating,
                Title = createMovieCommand.Title,
                ReleaseDate = createMovieCommand.ReleaseDate,
               
               
            });
            await _context.SaveChangesAsync();
        }


    }
}
