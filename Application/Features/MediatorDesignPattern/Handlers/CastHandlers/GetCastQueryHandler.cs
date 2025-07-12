using Application.Features.MediatorDesignPattern.Queries.CastQueries;
using Application.Features.MediatorDesignPattern.Result.CastResult;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class GetCastQueryHandler : IRequestHandler<GetCastQuery, List<GetCastQueryResult>>
    {
        private readonly MyContext _context;

        public GetCastQueryHandler(MyContext context)
        {
            _context = context;
        }

        public async Task<List<GetCastQueryResult>> Handle(GetCastQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Casts.ToListAsync();

            return entity.Select(x => new GetCastQueryResult
            {
                Biography = x.Biography,
                Overview = x.Overview,
                CastId = x.CastId,
                ImageUrl = x.ImageUrl,
                Name = x.Name,
                Surname = x.Surname,
                Title = x.Title,

            }).ToList();
        }
    }
}
