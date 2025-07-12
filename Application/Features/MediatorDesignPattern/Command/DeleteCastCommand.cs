using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatorDesignPattern.Command
{
    public class DeleteCastCommand:IRequest
    {
        public int CastId { get; set; }

        public DeleteCastCommand(int id)
        {
            CastId = id;
        }
    }
}
