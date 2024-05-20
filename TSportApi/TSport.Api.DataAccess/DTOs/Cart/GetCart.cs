using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSport.Api.DataAccess.DTOs.Cart
{
    public class getOrderDTO
    {
        public int Id { get; set; }

        public string? Code { get; set; }

        public DateTime? OrderDate { get; set; }

        public string? Status { get; set; }

        public decimal? Total { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedAccountId { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedAccountId { get; set; }
    }

    public class getCartDTO
    {
        public int OrderId { get; set; }
        public int CreatedAccountId { get; set; }

        //public int ShirtId { get; set; }

        public string? Code { get; set; }

        public decimal? Subtotal { get; set; }
        public List<CartItemDTO> Items { get; set; }
       


    }
    public class CartItemDTO
    {
        public int? Quantity { get; set; }

        public string? Status { get; set; }

        // Table Shirt  cart -> price ,color ,status -> de canh bao cart còn hàng không ? , 

        public string? Size { get; set; }

        public bool? HasSignature { get; set; }

        public decimal? Price { get; set; }

        public string? Color { get; set; }

    }
}
