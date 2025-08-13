using Abstractions.Interface;
using Application.Features.MediatorDesignPattern.Queries.MovieQueries;
using AutoMapper;
using DTO.ExternalApiDto.Movie;
using DTO.MovieDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatorDesignPattern.Handlers.MovieHandlers
{
    public class GetMovieListQueryHandler : IRequestHandler<GetMovieListQuery, List<MovieDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMovieListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<MovieDto>> Handle(GetMovieListQuery request, CancellationToken cancellationToken)
        {
           var movieList = await _unitOfWork.MovieRepository.GetListAsync();
           var mappingdto = _mapper.Map<List<MovieDto>>(movieList);
           return mappingdto;

        }
    }
}
