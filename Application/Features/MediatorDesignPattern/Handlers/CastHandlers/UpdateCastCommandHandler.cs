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
    public class UpdateCastCommandHandler : IRequestHandler<UpdateCastCommand>
    {
        private readonly MyContext _context;

        public UpdateCastCommandHandler(MyContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateCastCommand request, CancellationToken cancellationToken)
        {         
            var entity = await _context.Casts.FindAsync(request.CastId);

            entity.Surname= request.Surname;
            entity.Biography= request.Biography;
            entity.ImageUrl= request.ImageUrl;
            entity.Name= request.Name;
            entity.Overview= request.Overview;
            entity.Title= request.Title;
            await _context.SaveChangesAsync();
        }
    }
}
