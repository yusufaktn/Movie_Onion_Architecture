using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS_DesignPattern.Command.MovieCommand
{
    public class DeleteMovieCommand
    {
        public DeleteMovieCommand(int movieId)
        {
            MovieId = movieId;
        }

        public int MovieId { get; set; }
        
    }
}
