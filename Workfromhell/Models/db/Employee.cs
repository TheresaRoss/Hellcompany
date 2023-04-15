using System;
using System.Collections.Generic;

namespace Workfromhell.Models.db;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? Name { get; set; }

    public string? Lastname { get; set; }

    public short? Age { get; set; }

    public double? Salary { get; set; }

    public string? Position { get; set; }

    public DateTime? Joined { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
