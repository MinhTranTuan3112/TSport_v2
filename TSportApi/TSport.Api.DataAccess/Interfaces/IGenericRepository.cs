using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TSport.Api.DataAccess.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Entities { get; }

        Task<List<T>> FindAsync(Expression<Func<T, bool>> expression);

        Task<T?> FindOneAsync(Expression<Func<T, bool>> expression, bool hasTrackings = true);

        Task<T?> GetByIdAsync(int id);

        Task<List<T>> GetAllAsync();

        Task AddAsync(T TEntity);

        Task UpdateAsync(T TEntity);

        Task DeleteAsync(T TEntity);
    }
}