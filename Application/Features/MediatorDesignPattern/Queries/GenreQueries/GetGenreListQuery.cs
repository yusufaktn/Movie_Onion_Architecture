using DTO.GenreDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatorDesignPattern.Queries.GenreQueries
{
    public class GetGenreListQuery:IRequest<List<GenreDto>>
    {
    }
}
