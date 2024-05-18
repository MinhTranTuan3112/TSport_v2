using System;
using System.Collections.Generic;

namespace TSport.Api.DataAccess.Models;

public partial class Club
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? LogoUrl { get; set; }

    public string? Status { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedAccountId { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? ModifiedAccountId { get; set; }

    public virtual Account CreatedAccount { get; set; } = null!;

    public virtual Account? ModifiedAccount { get; set; }

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();

    public virtual ICollection<Season> Seasons { get; set; } = new List<Season>();
}
