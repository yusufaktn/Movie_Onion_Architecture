using Application.Features.CQRS_DesignPattern.Command.MovieCommand;
using AutoMapper;
using Domain.Entity;
using DTO.MovieDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDto>();
            CreateMap<CreateMovieCommand, Movie>();

        }
    }
}
