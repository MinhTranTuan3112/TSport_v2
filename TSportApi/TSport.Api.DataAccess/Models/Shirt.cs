using System;
using System.Collections.Generic;

namespace TSport.Api.DataAccess.Models;

public partial class Shirt
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public int? ShirtEditionId { get; set; }

    public int? SeasonPlayerId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedAccountId { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedAccountId { get; set; }

    public virtual Account CreatedAccount { get; set; } = null!;

    public virtual Account? ModifiedAccount { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual SeasonPlayer? SeasonPlayer { get; set; }

    public virtual ShirtEdition? ShirtEdition { get; set; }
}
