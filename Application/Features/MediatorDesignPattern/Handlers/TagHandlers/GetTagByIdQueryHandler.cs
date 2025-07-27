using Application.Features.MediatorDesignPattern.Queries.TagQueries;
using Application.Features.MediatorDesignPattern.Result.TagResult;
using MediatR;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatorDesignPattern.Handlers.TagHandlers
{
    public class GetTagByIdQueryHandler:IRequestHandler<GetTagByIdQuery,GetTagByIdQueyResult>
    {

        private readonly MyContext _context;

        public GetTagByIdQueryHandler(MyContext context)
        {
            _context = context;
        }

        public async Task<GetTagByIdQueyResult> Handle(GetTagByIdQuery getTagByIdQuery ,CancellationToken cancellationToken)
        {
            var get_tag = await _context.Tags.FindAsync(getTagByIdQuery.TagId);
            return new GetTagByIdQueyResult
            {
                TagId = get_tag.TagId,
                Title = get_tag.Title,
            };

        }

    }
}
