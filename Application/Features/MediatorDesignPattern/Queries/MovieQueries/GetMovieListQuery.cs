using DTO.ExternalApiDto.Movie;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatorDesignPattern.Queries.MovieQueries
{
    public class GetMovieListQuery:IRequest<List<ExternalMovieDto>>
    {
    }
}
