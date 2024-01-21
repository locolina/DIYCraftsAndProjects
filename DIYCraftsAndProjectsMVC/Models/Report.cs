using System;
using System.Collections.Generic;

namespace DIYCraftsAndProjectsMVC.Models;

public partial class Report
{
    public int ReportId { get; set; }

    public int ReportedId { get; set; }

    public int ReportingId { get; set; }

    public string Description { get; set; } = null!;

    public int ReportedTypeId { get; set; }

    public DateTime? Sent { get; set; }

    public bool? Resolved { get; set; }

    public virtual User Reported { get; set; } = null!;

    public virtual ReportedType ReportedType { get; set; } = null!;

    public virtual User Reporting { get; set; } = null!;
}
