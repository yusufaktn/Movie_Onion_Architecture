using Application.Features.MediatorDesignPattern.Command.TagCommand;
using Application.Features.MediatorDesignPattern.Handlers.TagHandlers;
using Application.Features.MediatorDesignPattern.Queries.TagQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetTagList()
        {
            var result = await _mediator.Send(new GetTagQuery());
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTag(CreateTagCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpGet("GetTagById")]
        public async Task<IActionResult> GetTagById(int id)
        {
            var result = await _mediator.Send(new GetTagByIdQuery(id));
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTag(int id)
        {
            await _mediator.Send(new DeleteTagCommand(id));
            return Ok("Silme işlemi başarılı.");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateTag(UpdateTagCommand updateTagCommand)
        {
           await _mediator.Send(updateTagCommand);
           return Ok("Güncelleme işlemi başarılı");
        }
    }
}
