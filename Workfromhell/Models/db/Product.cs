using System;
using System.Collections.Generic;

namespace Workfromhell.Models.db;

public partial class Product
{
    public int ProductId { get; set; }

    public int TeamId { get; set; }

    public string? Name { get; set; }

    public double? Price { get; set; }

    public string? Description { get; set; }

    public int? Quantity { get; set; }

    public double? Quality { get; set; }

    public virtual Team Team { get; set; } = null!;
}
