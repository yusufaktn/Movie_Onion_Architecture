using Abstractions.Interface;
using Application.Features.MediatorDesignPattern.Queries.GenreQueries;
using AutoMapper;
using DTO.GenreDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatorDesignPattern.Handlers.GenreHandlers
{
    public class GetGenreListQueryHandler : IRequestHandler<GetGenreListQuery, List<GenreDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetGenreListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GenreDto>> Handle(GetGenreListQuery getGenreListQuery, CancellationToken cancellationToken)
        {
            var genrelist = await _unitOfWork.GenreRepository.GetListAsync();
            var mappingdto = _mapper.Map<List<GenreDto>>(genrelist);
            return mappingdto;

        }

    }
}
