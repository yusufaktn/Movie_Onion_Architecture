using Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstractions.Interface
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IMovieRepository MovieRepository { get; }
        IGenreRepository GenreRepository { get; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
