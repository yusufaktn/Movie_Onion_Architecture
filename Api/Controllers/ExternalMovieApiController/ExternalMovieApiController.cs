using Application.Features.MediatorDesignPattern.Queries.External_MovieApiQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.ExternalMovieApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalMovieApiController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExternalMovieApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetGenres")]
        public async Task<IActionResult> GetGenres()
        {
            var genres = await _mediator.Send(new GetGenresListQuery());
            return Ok(genres);
        }
    }
}
