using Application.Features.CQRS_DesignPattern.Command.MovieCommand;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS_DesignPattern.Handlers.MovieHandlers
{
    public class UpdateMovieCommandHandler
    {
        private MyContext _context;
        public UpdateMovieCommandHandler(MyContext context )
        {
            _context = context;
        }

        public async Task Handle(UpdateMovieCommand updateMovieCommand)
        {
            var value = await _context.Movies.FindAsync(updateMovieCommand.MovieId );
            if( value == null ) 
            {
                throw new Exception("Not Update");
                
            }
            value.Rating = updateMovieCommand.Rating;
            value.Title = updateMovieCommand.Title;
            value.Description = updateMovieCommand.Description;
            value.Duration = updateMovieCommand.Duration;
            value.CoverImageUrl = updateMovieCommand.CoverImageUrl;
            value.CreatedYear = updateMovieCommand.CreatedYear;
            value.ReleaseDate = updateMovieCommand.ReleaseDate;

            await _context.SaveChangesAsync();

        }
    }
}
