using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TSport.Api.DataAccess.Contexts;
using TSport.Api.DataAccess.Interfaces;

namespace TSport.Api.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TsportDbContext _context;

        public GenericRepository(TsportDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Entities => _context.Set<T>();

        public Task AddAsync(T TEntity)
        {
            _context.Add(TEntity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(T TEntity)
        {
            _context.Remove(TEntity);
            return Task.CompletedTask;
        }

        public async Task<List<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T?> FindOneAsync(Expression<Func<T, bool>> expression, bool hasTrackings = true)
        {
            return hasTrackings ? await _context.Set<T>().FirstOrDefaultAsync(expression)
                                : await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public Task UpdateAsync(T TEntity)
        {
            _context.Set<T>().Update(TEntity);
            return Task.CompletedTask;
        }
    }
}