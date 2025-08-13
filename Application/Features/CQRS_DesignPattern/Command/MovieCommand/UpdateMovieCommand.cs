using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS_DesignPattern.Command.MovieCommand
{
    public class UpdateMovieCommand
    {
        public int MovieId { get; set; }
        public string backdrop_path { get; set; }
        public List<int> genre_ids { get; set; }
        public string original_language { get; set; }
        public string overview { get; set; }
        public string poster_path { get; set; }
        public string title { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }

    }
}
