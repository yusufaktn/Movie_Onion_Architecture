using Application.Features.MediatorDesignPattern.Queries.GenreQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Genre
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GenreController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetGenreList")]
        public async Task<IActionResult> GetGenreList()
        {
            var response = await _mediator.Send(new GetGenreListQuery());
            return Ok(response);    

        }



    }
}
