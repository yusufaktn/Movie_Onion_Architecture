using DTO.MovieDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatorDesignPattern.Queries.MovieQueries
{
    public class GetMovieByGenreQuery:IRequest<List<MovieDto>>
    {
        public List<int> GenreIds { get; set; }

        public GetMovieByGenreQuery(List<int> genreIds)
        {
            GenreIds = genreIds;
        }
    }
}
