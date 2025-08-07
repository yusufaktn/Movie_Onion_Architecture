using Application.Features.MediatorDesignPattern.Queries.External_MovieApiQueries;
using DTO.ExternalApiDto.Genre;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatorDesignPattern.Handlers.External_MovieApiHandlers
{
    public class GetGenreListQueryHandler:IRequestHandler<GetGenresListQuery,List<ExternalGenreDto>>
    {
        private readonly IExternalApiService _externalApiService;
        private readonly MyContext _context;

        public GetGenreListQueryHandler(IExternalApiService externalApiService)
        {
            _externalApiService = externalApiService;
        }

        public async Task<List<ExternalGenreDto>> Handle(GetGenresListQuery getGenresListQuery,CancellationToken cancellationToken)
        {
            var genreList = await _externalApiService.GetGenreList();
            return genreList;

            
        }
    }
}
