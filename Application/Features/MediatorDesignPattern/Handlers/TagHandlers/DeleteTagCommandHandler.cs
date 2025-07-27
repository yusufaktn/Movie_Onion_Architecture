using Application.Features.MediatorDesignPattern.Command.TagCommand;
using MediatR;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatorDesignPattern.Handlers.TagHandlers
{
    public class DeleteTagCommandHandler:IRequestHandler<DeleteTagCommand>
    {
        private readonly MyContext _context;

        public DeleteTagCommandHandler(MyContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteTagCommand deleteTagCommand,CancellationToken cancellationToken)
        {
            var get_tag = await _context.Tags.FindAsync(deleteTagCommand.TagId);
             _context.Tags.Remove(get_tag);
            await _context.SaveChangesAsync();

        }

    }
}
