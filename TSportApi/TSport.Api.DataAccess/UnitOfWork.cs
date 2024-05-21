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
        private readonly Lazy<IAccountRepository> _accountRepository;
        private readonly Lazy<IOrderRepository> _orderRepository;


        public UnitOfWork(TsportDbContext context)
        {
            _context = context;
            _shirtRepository = new Lazy<IShirtRepository>(() => new ShirtRepository(context));
            _accountRepository = new Lazy<IAccountRepository>(() => new AccountRepositoy(context));
            _orderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(context));
        }
        public IOrderRepository GetOrderRepository()
        {
            return _orderRepository.Value;
        }

        public IAccountRepository GetAccountRepository()
        {
            return _accountRepository.Value;
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