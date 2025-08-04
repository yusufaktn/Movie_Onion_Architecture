using DTO.ExternalMovieDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Interface
{
    public interface IExternalApiService
    {
        Task<List<ExternalGenreDto>> GetMovieList();
    }
}
