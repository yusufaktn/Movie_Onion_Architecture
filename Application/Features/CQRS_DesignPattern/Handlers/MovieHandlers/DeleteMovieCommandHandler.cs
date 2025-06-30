using Application.Features.CQRS_DesignPattern.Command.MovieCommand;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS_DesignPattern.Handlers.MovieHandlers
{
    public class DeleteMovieCommandHandler
    {
        private MyContext _context;
        public DeleteMovieCommandHandler(MyContext context)
        {
            _context = context;

        }

        public async Task Handle(DeleteMovieCommand deleteMovieCommand)
        {
            var value = await _context.Movies.FindAsync(deleteMovieCommand.MovieId);
            if (value == null)
            {
                throw new Exception("Not Found Delete Movie");
                
            }
            _context.Movies.Remove(value);
            await _context.SaveChangesAsync();


        }


    }
}
