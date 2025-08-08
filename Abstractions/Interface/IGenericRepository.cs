using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetListAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter); 
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
