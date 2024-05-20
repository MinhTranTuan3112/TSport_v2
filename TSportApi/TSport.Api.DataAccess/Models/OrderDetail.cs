using System;
using System.Collections.Generic;

namespace TSport.Api.DataAccess.Models;

public partial class OrderDetail
{
    public int OrderId { get; set; }

    public int ShirtId { get; set; }

    public string? Code { get; set; }

    public decimal? Subtotal { get; set; }

    public int? Quantity { get; set; }

    public string? Status { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Shirt Shirt { get; set; } = null!;
    // 1 order details co 1 Shirtedition ?
    public virtual ShirtEdition ShirtEditions { get; set; } = null!;

}
