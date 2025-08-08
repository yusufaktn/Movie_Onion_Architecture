using Abstractions.Interface;
using Application.Features.MediatorDesignPattern.Queries.MovieQueries;
using DTO.ExternalApiDto.Movie;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatorDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieListQueryHandler : IRequestHandler<GetMovieListQuery, List<ExternalMovieDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetMovieListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ExternalMovieDto>> Handle(GetMovieListQuery request, CancellationToken cancellationToken)
        {
           var movieList = await _unitOfWork.MovieRepository.GetListAsync();
            return movieList.Select(x => new ExternalMovieDto
            {
                id = x.MovieId,
                title = x.Title,
                overview =x.Description,
                release_date = x.ReleaseDate,
                poster_path = x.CoverImageUrl,
                vote_average = ((double)x.Rating)
            }).ToList();

        }
    }
}
