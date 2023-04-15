using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Workfromhell.Models.db;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? Name { get; set; }

    public string? Lastname { get; set; }

    [Range(1, 100,ErrorMessage = "Age should not exceed 100 or lower than 1")]
    public short? Age { get; set; }

    public double? Salary { get; set; }

    public string? Position { get; set; }

    public DateTime? Joined { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
