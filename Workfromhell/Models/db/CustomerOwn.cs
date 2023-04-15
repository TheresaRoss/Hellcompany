using System;
using System.Collections.Generic;

namespace Workfromhell.Models.db;

public partial class CustomerOwn
{
    public int ProductId { get; set; }

    public int CustomerId { get; set; }

    public int? Quantity { get; set; }

    public int? TotalPrice { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
