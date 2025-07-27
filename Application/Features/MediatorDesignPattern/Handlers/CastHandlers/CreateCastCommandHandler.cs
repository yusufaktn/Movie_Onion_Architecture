using Application.Features.MediatorDesignPattern.Command.CastCommand;
using Domain.Entity;
using MediatR;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class CreateCastCommandHandler : IRequestHandler<CreateCastCommand>
    {
        private readonly MyContext _context;

        public CreateCastCommandHandler(MyContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateCastCommand request, CancellationToken cancellationToken)
        {

           await  _context.Casts.AddAsync(new Cast
            {
                Biography = request.Biography,
                ImageUrl = request.ImageUrl,
                Name = request.Name,
                Surname = request.Surname,
                Title = request.Title,
                Overview = request.Overview
            });
            await _context.SaveChangesAsync();

        }
    }
}
