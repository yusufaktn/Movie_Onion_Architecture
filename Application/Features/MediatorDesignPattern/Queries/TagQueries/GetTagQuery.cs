using Application.Features.MediatorDesignPattern.Result.TagResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatorDesignPattern.Queries.TagQueries
{
    public class GetTagQuery:IRequest<List<GetTagQueryResult>>
    {
    }
}
