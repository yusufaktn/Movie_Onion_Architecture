using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Seed.Command
{
    public class FetchAndSeedDataCommand:IRequest<string>
    {
    }
}
