using System;
using System.Collections.Generic;

namespace Workfromhell.Models.db;

public partial class Team
{
    public int TeamId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
