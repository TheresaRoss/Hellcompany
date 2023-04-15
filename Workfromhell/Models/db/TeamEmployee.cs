using System;
using System.Collections.Generic;

namespace Workfromhell.Models.db;

public partial class TeamEmployee
{
    public int EmployeeId { get; set; }

    public int TeamId { get; set; }

    public virtual Employee Employee { get; set; } = null!;

    public virtual Team Team { get; set; } = null!;
}
