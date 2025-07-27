using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatorDesignPattern.Command.TagCommand
{
    public class DeleteTagCommand:IRequest
    {
        public int TagId { get; set; }

        public DeleteTagCommand(int tagId)
        {
            TagId = tagId;
        }
    }
}
