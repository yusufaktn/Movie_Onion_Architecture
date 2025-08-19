using Abstractions.Interface;
using Application.Features.MediatorDesignPattern.Queries.MovieQueries;
using AutoMapper;
using DTO.MovieDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatorDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieByGenreQueryHandler : IRequestHandler<GetMovieByGenreQuery, List<MovieDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMovieByGenreQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<MovieDto>> Handle(GetMovieByGenreQuery request, CancellationToken cancellationToken=default)
        {
            var movies = await _unitOfWork.MovieRepository.GetMoviesByGenreAsync(request.GenreIds);
            var mappingdto = _mapper.Map<List<MovieDto>>(movies);
            return mappingdto;
        }
    }
}
