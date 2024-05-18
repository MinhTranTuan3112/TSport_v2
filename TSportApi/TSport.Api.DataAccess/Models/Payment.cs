using System;
using System.Collections.Generic;

namespace TSport.Api.DataAccess.Models;

public partial class Payment
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? PaymentMethod { get; set; }

    public string? PaymentName { get; set; }

    public string Status { get; set; } = null!;

    public int? OrderId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedAccountId { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedAccountId { get; set; }

    public virtual Account CreatedAccount { get; set; } = null!;

    public virtual Account? ModifiedAccount { get; set; }

    public virtual Order? Order { get; set; }
}
