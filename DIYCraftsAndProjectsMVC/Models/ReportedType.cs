using System;
using System.Collections.Generic;

namespace DIYCraftsAndProjectsMVC.Models;

public partial class ReportedType
{
    public int ReportedTypeId { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
}
