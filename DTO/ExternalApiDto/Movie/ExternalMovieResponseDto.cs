using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ExternalApiDto.Movie
{
    public class ExternalMovieResponseDto
    {
        public int page { get; set; }
        public List<ExternalMovieDto> results { get; set; }
    }
}
