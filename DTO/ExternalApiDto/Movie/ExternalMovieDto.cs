using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ExternalApiDto.Movie
{
    public class ExternalMovieDto
    {
        public int id { get; set; }
        public string title { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public string poster_path { get; set; }
        public DateTime release_date { get; set; }
        public double vote_average { get; set; }

    }
}
