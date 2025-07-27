using Application.Features.MediatorDesignPattern.Queries.TagQueries;
using Application.Features.MediatorDesignPattern.Result.TagResult;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatorDesignPattern.Handlers.TagHandlers
{
    public class GetTagQueryHandler:IRequestHandler<GetTagQuery,List<GetTagQueryResult>>
    {

        private readonly MyContext _context;

        public GetTagQueryHandler(MyContext context)
        {
            _context = context;
        }

        public async Task<List<GetTagQueryResult>> Handle(GetTagQuery getTagQuery, CancellationToken cancellationToken)
        {
            var get_tag = await _context.Tags.ToListAsync();
            return get_tag.Select(x => new GetTagQueryResult
            {
                TagId =x.TagId,
                Title = x.Title,

            }).ToList();
        }
    }
}
