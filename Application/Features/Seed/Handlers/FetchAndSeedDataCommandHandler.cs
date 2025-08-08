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
                CreatedDate = DateTime.Now,
            });
            await _unitOfWork.GenreRepository.AddRangeAsync(saveGenres);


            var fromapiMovie = await _externalApiService.GetMovieList(1);
            if (fromapiMovie is null || !fromapiMovie.Any())
            {
                return "Movie getirilemedi.";

            }
            var saveMovie = fromapiMovie.Select(x=> new Movie
            {
                MovieId=x.id,
                Title=x.title,
                Description = x.overview,
                CreatedDate=DateTime.Now,
                CoverImageUrl =x.poster_path,
                Rating = ((decimal)x.vote_average),
                ReleaseDate = x.release_date,
                Duration = 0,
                
            });
            await _unitOfWork.MovieRepository.AddRangeAsync(saveMovie);

            await _unitOfWork.SaveChangesAsync();
            return $"Başarıyla veri tabanına api verileri eklendi.";

        }
    }
}
