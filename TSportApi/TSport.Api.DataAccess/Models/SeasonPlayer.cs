using System;
using System.Collections.Generic;

namespace TSport.Api.DataAccess.Models;

public partial class SeasonPlayer
{
    public int Id { get; set; }

    public int SeasonId { get; set; }

    public int PlayerId { get; set; }

    public virtual Player Player { get; set; } = null!;

    public virtual Season Season { get; set; } = null!;

    public virtual ICollection<Shirt> Shirts { get; set; } = new List<Shirt>();
}
