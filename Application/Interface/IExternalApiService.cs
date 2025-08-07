using DTO.ExternalApiDto.Genre;
using DTO.ExternalApiDto.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Interface
{
    public interface IExternalApiService
    {
        Task<List<ExternalGenreDto>> GetGenreList();
        Task <List<ExternalMovieDto>> GetMovieList(int page);

        
    }
}
