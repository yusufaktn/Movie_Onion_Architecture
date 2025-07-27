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
    public class UpdateTagCommandHandler:IRequestHandler<UpdateTagCommand>
    {
        private readonly MyContext _context;

        public UpdateTagCommandHandler(MyContext context)
        {
            _context = context;
        }


        public async Task Handle(UpdateTagCommand updateTagCommand,CancellationToken cancellationToken)
        {
            var get_tag = await _context.Tags.FindAsync(updateTagCommand.TagId);
            get_tag.Title= updateTagCommand.Title;

            await _context.SaveChangesAsync();

        }
    }
}
