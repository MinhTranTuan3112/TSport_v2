using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSport.Api.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();

        IShirtRepository GetShirtRepository();

        IAccountRepository GetAccountRepository();
    }
}