using Application.Features.MediatorDesignPattern.Queries.External_MovieApiQueries;
using DTO.ExternalApiDto.Movie;
using MediatR;
using Persistence.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatorDesignPattern.Handlers.External_MovieApiHandlers
{
    public class GetMovieListQueryHandler:IRequestHandler<GetMovieListQuery,List<ExternalMovieDto>>
    {

        private readonly IExternalApiService _externalApiService;

        public GetMovieListQueryHandler(IExternalApiService externalApiService)
        {
            _externalApiService = externalApiService;
        }

        public async Task<List<ExternalMovieDto>> Handle(GetMovieListQuery getMovieListQuery ,CancellationToken cancellationToken)
        {
            var movielist = await _externalApiService.GetMovieList(1);
            return movielist;

        }
    }
}
