using Abstractions.Interface;
using Application.Features.Seed.Command;
using Application.Interface;
using Domain.Entity;
using MediatR;
using Persistence.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Seed.Handlers
{
    public class FetchAndSeedDataCommandHandler:IRequestHandler<FetchAndSeedDataCommand,string>
    {
        private readonly IExternalApiService _externalApiService;
        private readonly IUnitOfWork _unitOfWork;

        public FetchAndSeedDataCommandHandler(IExternalApiService externalApiService, IUnitOfWork unitOfWork)
        {
            _externalApiService = externalApiService;
            _unitOfWork =unitOfWork;
        }

        public async Task<string> Handle(FetchAndSeedDataCommand command,CancellationToken cancellationToken)
        {
            if(await _unitOfWork.MovieRepository.AnyAsync())
            {
                return "Veritabanı verleri mevcut";
            }
            var fromapiGenres = await _externalApiService.GetGenreList();
            if(fromapiGenres is null || !fromapiGenres.Any())
            {
                return "Genre getirilemedi.";

            }
            var saveGenres = fromapiGenres.Select(x => new Genre
            {
                GenreId=x.id,
                Name=x.name,            
            });
            await _unitOfWork.GenreRepository.AddRangeAsync(saveGenres);


            var fromapiMovie = await _externalApiService.GetMovieList(1);
            if (fromapiMovie is null || !fromapiMovie.Any()) { return "Movie getirilemedi."; }

            // Filmleri ve ilişkilerini kurarak ekliyoruz
            foreach (var x in fromapiMovie)
            {
                var newMovie = new Movie
                {
                   
                    MovieId = x.id,
                    Title = x.title,
                    Overview = x.overview,
                    CreatedDate = DateTime.Now,
                    CoverImageUrl = x.poster_path,
                    Vote_average = x.vote_average,
                    Vote_count = x.vote_count,
                    Release_date = x.release_date,
                    Adult = x.adult,
                    Original_language = x.original_language,
                    Original_title = x.original_title,
                    Popularity = x.popularity,
                    Poster_path = x.poster_path,
                };

                // Her bir genre ID için MovieGenre ilişki nesnesi oluşturup filme ekliyoruz.
                foreach (var genreId in x.genre_ids)
                {
                    newMovie.MovieGenres.Add(new MovieGenre
                    {
                        GenreId = genreId,
                                                           
                    });
                }

                await _unitOfWork.MovieRepository.CreateAsync(newMovie);
            }

            await _unitOfWork.SaveChangesAsync();
            return $"Başarıyla veritabanına api verileri eklendi.";

        }
    }
}
