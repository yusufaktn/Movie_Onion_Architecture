 using Application.Features.CQRS_DesignPattern.Command.CategoryCommand;
using Application.Features.CQRS_DesignPattern.Command.MovieCommand;
using Application.Features.CQRS_DesignPattern.Handlers.MovieHandlers;
using Application.Features.CQRS_DesignPattern.Queries.MovieQueries;
using Application.Features.MediatorDesignPattern.Handlers.MovieHandlers;
using Application.Features.MediatorDesignPattern.Queries.MovieQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Movies
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        private readonly CreateMovieCommandHandler _createMovieCommandHandler;
        private readonly DeleteMovieCommandHandler _deleteMovieCommandHandler;
        private readonly UpdateMovieCommandHandler _updateMovieCommandHandler;
        private readonly GetMovieByIdQueryHandler _getMovieByIdQueryHandler;
        private readonly GetMovieQueryHandler _getMovieQueryHandler;
        private readonly GetMovieByGenreQueryHandler _getMovieByGenreQueryHandler;

        public MoviesController(CreateMovieCommandHandler createMovieCommandHandler,
            DeleteMovieCommandHandler deleteMovieCommandHandler,
            UpdateMovieCommandHandler updateMovieCommandHandler,
            GetMovieByIdQueryHandler getMovieByIdQueryHandler,
            GetMovieQueryHandler getMovieQueryHandler,
            GetMovieByGenreQueryHandler getMovieByGenreQueryHandler)
        {
            _createMovieCommandHandler = createMovieCommandHandler;
            _deleteMovieCommandHandler = deleteMovieCommandHandler;
            _updateMovieCommandHandler = updateMovieCommandHandler;
            _getMovieByIdQueryHandler = getMovieByIdQueryHandler;
            _getMovieQueryHandler = getMovieQueryHandler;
            _getMovieByGenreQueryHandler = getMovieByGenreQueryHandler;
        }


        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var movie = await _getMovieQueryHandler.Handle();
            return Ok(movie);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(CreateMovieCommand createMovieCommand)
        {
            await _createMovieCommandHandler.Handle(createMovieCommand);
            return Ok("Created Successful");

        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovie(UpdateMovieCommand updateMovieCommand)
        {
            await _updateMovieCommandHandler.Handle(updateMovieCommand);
            return Ok("Updated Successful");

        }

        [HttpDelete]

        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _deleteMovieCommandHandler.Handle(new DeleteMovieCommand(id));
            return Ok("Deleted Successful");
        }

        [HttpGet("GetMovieById")]

        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _getMovieByIdQueryHandler.Handle(new GetMovieByIdQuery(id));
            return Ok(movie);

        }

        [HttpGet("GetMovieByGenre")]
        public async Task<IActionResult> GetMovieByGenre([FromQuery]List<int> genre_id)
        {
            var response = await _getMovieByGenreQueryHandler.Handle(new GetMovieByGenreQuery(genre_id));
            return Ok(response);

        }









    }
}
