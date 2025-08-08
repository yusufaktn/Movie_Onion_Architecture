using Abstractions.Interface;
using Application.Interface;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyContext _context;

        public IMovieRepository MovieRepository {  get; private set; }

        public IGenreRepository GenreRepository {  get; private set; }

        public UnitOfWork(MyContext context)
        {
            _context = context; 
            MovieRepository = new MovieRepository(_context);
            GenreRepository = new GenreRepository(_context);
            
        }
     

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
          return  await _context.SaveChangesAsync(cancellationToken);
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
