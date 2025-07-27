using Application.Features.MediatorDesignPattern.Command.CastCommand;
using Application.Features.MediatorDesignPattern.Command.TagCommand;
using Domain.Entity;
using MediatR;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatorDesignPattern.Handlers.TagHandlers
{
    public class CreateTagCommandHandler:IRequestHandler<CreateTagCommand>
    {
        private readonly MyContext _context;

        public CreateTagCommandHandler(MyContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateTagCommand tagCommand,CancellationToken cancellationToken)
        {
            await _context.Tags.AddAsync(new Tag
            {
                Title = tagCommand.Title,

            });
            await _context.SaveChangesAsync();
        }

    }
}
