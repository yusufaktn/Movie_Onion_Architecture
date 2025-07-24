using Application.Features.MediatorDesignPattern.Command.CastCommand;
using Application.Features.MediatorDesignPattern.Queries.CastQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Casts
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CastsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task <IActionResult> GetCastsList()
        {
            var result = await _mediator.Send(new GetCastQuery());
            return Ok(result);

            /*Bu şu anlama gelir:
                “Ben GetCastQuery diye bir sorgu yolluyorum. Bununla ilgilenen bir Handler varsa, o işlesin.”
            
                Controller → Send(new GetCastQuery())

                MediatR → GetCastQueryHandler'ı bulur.

                Handler → DB'den veri çeker, GetCastQueryResult listesi döner.

                Controller → Ok(result) ile döner.
             */
        }

        [HttpPost]
        public async Task<IActionResult> CreateCast(CreateCastCommand createCastCommand)
        {
            await _mediator.Send(createCastCommand);
            return Ok("Oluşturma işlemi başarılı");

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCast(int id)
        {
           await _mediator.Send(new DeleteCastCommand(id));
           return Ok("Silme işlemi başarılı");
        }

        [HttpGet("GetCastById")]
        public async Task<IActionResult> GetCastById(int id)
        {
          var result = await _mediator.Send(new GetCastByIdQuery(id));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCast(UpdateCastCommand updateCastCommand)
        {
           await _mediator.Send(updateCastCommand);
           return Ok("Güncelleme işlemi başarılı");
        }
    }
}
