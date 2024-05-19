using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSport.Api.DataAccess.Contexts;
using TSport.Api.DataAccess.Interfaces;
using TSport.Api.DataAccess.Models;

namespace TSport.Api.DataAccess.Repositories
{
    public class AccountRepositoy : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepositoy(TsportDbContext context) : base(context)
        {
        }
    }
}