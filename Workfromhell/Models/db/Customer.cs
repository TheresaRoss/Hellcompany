using System;
using System.Collections.Generic;

namespace Workfromhell.Models.db;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? Name { get; set; }

    public string? Lastname { get; set; }

    public string? Address { get; set; }

    public string? Sex { get; set; }
}
