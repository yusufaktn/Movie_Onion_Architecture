 using Application.Features.CQRS_DesignPattern.Command.CategoryCommand;
using Application.Features.CQRS_DesignPattern.Command.MovieCommand;
using Application.Features.CQRS_DesignPattern.Handlers.MovieHandlers;
using Application.Features.CQRS_DesignPattern.Queries.MovieQueries;
using Application.Features.MediatorDesignPattern.Handlers.MovieHandlers;
using Application.Features.MediatorDesignPattern.Queries.MovieQueries;
using Domain.Entity;
using DTO.MovieDto;
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
            var response = movie.Select(movie => new MovieDto
            {
                MovieId = movie.id,
                Title = movie.title,
                Overview = movie.overview,
                Poster_path = movie.poster_path,
                Release_date = movie.release_date,
                Vote_average = movie.vote_average,
                Backdrop_path = movie.backdrop_path,
                Adult = movie.adult,
                Original_language = movie.original_language,
                Original_title = movie.original_title,
                Popularity = movie.popularity,
                Vote_count = movie.vote_count,
                Genre_ids = movie.genre_ids,
                
                
            }).ToList();
            return Ok(response);
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


        [HttpGet("GetMovieById/{id}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _getMovieByIdQueryHandler.Handle(new GetMovieByIdQuery(id));
            var response = new MovieDto
            {
                Adult = movie.adult,
                Backdrop_path = movie.backdrop_path,
                Genre_ids = movie.genre_ids,
                MovieId = movie.id,
                Original_language = movie.original_language,
                Original_title = movie.original_title,
                Overview = movie.overview,
                Popularity = movie.popularity,
                Poster_path = movie.poster_path,
                Release_date = movie.release_date,
                Title = movie.title,
                Vote_average = movie.vote_average,
                Vote_count = movie.vote_count,
            };


            return Ok(response);

        }

        [HttpGet("GetMovieByGenre")]
        public async Task<IActionResult> GetMovieByGenre([FromQuery]List<int> genre_id)
        {
            var response = await _getMovieByGenreQueryHandler.Handle(new GetMovieByGenreQuery(genre_id));
            return Ok(response);

        }









    }
}
