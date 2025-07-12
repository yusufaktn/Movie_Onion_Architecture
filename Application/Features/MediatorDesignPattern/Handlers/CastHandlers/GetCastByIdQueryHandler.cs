using Application.Features.MediatorDesignPattern.Queries.CastQueries;
using Application.Features.MediatorDesignPattern.Result.CastResult;
using MediatR;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class GetCastByIdQueryHandler : IRequestHandler<GetCastByIdQuery, GetCastByIdQueryResult>
    {
        private readonly MyContext _context;

        public GetCastByIdQueryHandler(MyContext context)
        {
            _context = context;
        }

        public async Task<GetCastByIdQueryResult> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
        {
            
            var entity = await _context.Casts.FindAsync(request.CastId);
            return new GetCastByIdQueryResult
            {
                CastId = entity.CastId,
                Biography = entity.Biography,
                ImageUrl = entity.ImageUrl,
                Name = entity.Name,
                Overview = entity.Overview,
                Surname = entity.Surname,
                Title = entity.Title,
            };



        }
    }
}
