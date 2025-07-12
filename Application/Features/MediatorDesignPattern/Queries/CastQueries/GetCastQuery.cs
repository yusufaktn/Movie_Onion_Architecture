using Application.Features.MediatorDesignPattern.Result.CastResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatorDesignPattern.Queries.CastQueries
{
    public class GetCastQuery:IRequest<List<GetCastQueryResult>>
    {
    }
}
