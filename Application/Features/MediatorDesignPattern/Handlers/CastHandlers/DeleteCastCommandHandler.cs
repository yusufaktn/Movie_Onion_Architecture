using Application.Features.MediatorDesignPattern.Command;
using MediatR;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class DeleteCastCommandHandler : IRequestHandler<DeleteCastCommand>
    {
        private readonly MyContext _context;

        public DeleteCastCommandHandler(MyContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteCastCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Casts.FindAsync(request.CastId);

             _context.Casts.Remove(entity);
            await _context.SaveChangesAsync();

        }
    }
}
