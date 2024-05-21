using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSport.Api.DataAccess.DTOs.Cart;
using TSport.Api.DataAccess.Models;

namespace TSport.Api.DataAccess.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>

    {
            Task<getCartDTO> getCartInfo(int userid);  



    }
}
