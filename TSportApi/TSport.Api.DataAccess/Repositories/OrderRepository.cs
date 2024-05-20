using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSport.Api.DataAccess.Contexts;
using TSport.Api.DataAccess.DTOs.Cart;
using TSport.Api.DataAccess.Interfaces;
using TSport.Api.DataAccess.Models;

namespace TSport.Api.DataAccess.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {

        private readonly TsportDbContext _context;

        public OrderRepository(TsportDbContext context) : base(context)
        {
            _context = context;

        }
        public async Task<getCartDTO> getCartInfo(int userid)
        {
            var userId = await _context.Orders
                //find, status = false -> don hang chua thanh toan
                .Where(o => o.CreatedAccountId == userid && o.Status== "false")
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.ShirtEditions)
                .ToListAsync();

            if (userId == null)
            {
                throw new Exception($"No orders found for userId {userId}");

            }


        }

    }
}
