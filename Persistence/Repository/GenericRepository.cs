using Application.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        private readonly MyContext _mycontext;

       
        public GenericRepository(MyContext mycontext)
        {
            _mycontext = mycontext;
            _dbSet = _mycontext.Set<T>();
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            
        }

        public async Task<bool> AnyAsync()
        {
           return await _dbSet.AnyAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);             
        }

        public async Task DeleteAsync(T entity)
        {
             _dbSet.Remove(entity);
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
          var result=  await _dbSet.FindAsync(filter);
           return result;

        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _dbSet.FindAsync(id);
            return result;
        }

        public Task<List<T>> GetListAsync()
        {
            var result = _dbSet.ToListAsync();
            return result;
        }

        public Task UpdateAsync(T entity)
        {
            _mycontext.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;      

        }

        
    }
}
