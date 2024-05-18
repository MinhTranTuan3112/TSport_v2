using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSport.Api.DataAccess.DTOs.Shirts;
using TSport.Api.DataAccess.Models;

namespace TSport.Api.DataAccess.Interfaces
{
    public interface IShirtRepository : IGenericRepository<Shirt>
    {
        
    }
}