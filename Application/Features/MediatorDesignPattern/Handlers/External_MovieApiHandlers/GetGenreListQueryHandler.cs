using Application.Features.MediatorDesignPattern.Queries.External_MovieApiQueries;
using DTO.ExternalMovieDto;
using MediatR;
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

        public GetGenreListQueryHandler(IExternalApiService externalApiService)
        {
            _externalApiService = externalApiService;
        }

        public async Task<List<ExternalGenreDto>> Handle(GetGenresListQuery getGenresListQuery,CancellationToken cancellationToken)
        {
            return await _externalApiService.GetMovieList();
        }
    }
}
