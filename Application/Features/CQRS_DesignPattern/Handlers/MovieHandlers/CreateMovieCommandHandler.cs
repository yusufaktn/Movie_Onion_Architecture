using Application.Features.CQRS_DesignPattern.Command.MovieCommand;
using AutoMapper;
using Domain.Entity;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS_DesignPattern.Handlers.MovieHandlers
{
    public class CreateMovieCommandHandler
    {
        private MyContext _context;
        private IMapper _mapper;
        public CreateMovieCommandHandler(MyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Handle(CreateMovieCommand createMovieCommand)
        {
            var mappingdto = _mapper.Map<Movie>(createMovieCommand);
           _context.Movies.Add(mappingdto);
            await _context.SaveChangesAsync();
        }


    }
}
