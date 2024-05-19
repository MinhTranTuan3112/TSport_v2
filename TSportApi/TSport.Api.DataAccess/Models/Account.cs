using System;
using System.Collections.Generic;

namespace TSport.Api.DataAccess.Models;

public partial class Account
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Username { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Gender { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public DateOnly? Dob { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime? RefreshTokenExpiryTime { get; set; }

    public string Role { get; set; } = null!;

    public string? Status { get; set; }

    public virtual ICollection<Club> ClubCreatedAccounts { get; set; } = new List<Club>();

    public virtual ICollection<Club> ClubModifiedAccounts { get; set; } = new List<Club>();

    public virtual ICollection<Order> OrderCreatedAccounts { get; set; } = new List<Order>();

    public virtual ICollection<Order> OrderModifiedAccounts { get; set; } = new List<Order>();

    public virtual ICollection<Payment> PaymentCreatedAccounts { get; set; } = new List<Payment>();

    public virtual ICollection<Payment> PaymentModifiedAccounts { get; set; } = new List<Payment>();

    public virtual ICollection<Player> PlayerCreatedAccounts { get; set; } = new List<Player>();

    public virtual ICollection<Player> PlayerModifiedAccounts { get; set; } = new List<Player>();

    public virtual ICollection<Season> SeasonCreatedAccounts { get; set; } = new List<Season>();

    public virtual ICollection<Season> SeasonModifiedAccounts { get; set; } = new List<Season>();

    public virtual ICollection<Shirt> ShirtCreatedAccounts { get; set; } = new List<Shirt>();

    public virtual ICollection<ShirtEdition> ShirtEditionCreatedAccounts { get; set; } = new List<ShirtEdition>();

    public virtual ICollection<ShirtEdition> ShirtEditionModifiedAccounts { get; set; } = new List<ShirtEdition>();

    public virtual ICollection<Shirt> ShirtModifiedAccounts { get; set; } = new List<Shirt>();
}
