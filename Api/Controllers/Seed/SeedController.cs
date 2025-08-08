using Application.Features.Seed.Command;
using Application.Features.Seed.Handlers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Seed
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SeedController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> Run()
        {
          var resultMessage =  await _mediator.Send(new FetchAndSeedDataCommand());
          return Ok(resultMessage);

        }

    }
}
