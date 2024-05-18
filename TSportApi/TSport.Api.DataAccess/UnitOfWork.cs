using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSport.Api.DataAccess.Contexts;
using TSport.Api.DataAccess.Interfaces;
using TSport.Api.DataAccess.Repositories;

namespace TSport.Api.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TsportDbContext _context;

        private readonly Lazy<IShirtRepository> _shirtRepository;

        public UnitOfWork(TsportDbContext context)
        {
            _context = context;
            _shirtRepository = new Lazy<IShirtRepository>(() => new ShirtRepository(context));
        }

        public IShirtRepository GetShirtRepository()
        {
            return _shirtRepository.Value;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}