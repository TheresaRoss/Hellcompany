using System;
using System.Collections.Generic;

namespace Workfromhell.Models.db;

public partial class Project
{
    public int ProjectId { get; set; }

    public int? EmployeeId { get; set; }

    public string? Name { get; set; }

    public DateTime? Startdate { get; set; }

    public DateTime? Enddate { get; set; }

    public double? Score { get; set; }

    public string? Comment { get; set; }

    public virtual Employee? Employee { get; set; }
}
