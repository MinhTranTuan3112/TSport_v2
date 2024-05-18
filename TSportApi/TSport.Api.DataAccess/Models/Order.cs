using System;
using System.Collections.Generic;

namespace TSport.Api.DataAccess.Models;

public partial class Order
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

    public virtual Account CreatedAccount { get; set; } = null!;

    public virtual Account? ModifiedAccount { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
