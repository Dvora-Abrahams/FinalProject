using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Supplier
{
    public int Id { get; set; }

    public string Company { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string RepresentativeName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
