using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSport.Api.DataAccess.Contexts;
using TSport.Api.DataAccess.DTOs.Shirts;
using TSport.Api.DataAccess.Interfaces;
using TSport.Api.DataAccess.Models;

namespace TSport.Api.DataAccess.Repositories
{
    public class ShirtRepository : GenericRepository<Shirt>, IShirtRepository
    {
        public ShirtRepository(TsportDbContext context) : base(context)
        {
        }

    }
}