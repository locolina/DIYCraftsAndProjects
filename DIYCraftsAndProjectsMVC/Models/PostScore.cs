using System;
using System.Collections.Generic;

namespace DIYCraftsAndProjectsMVC.Models;

public partial class PostScore
{
    public int PostScoreId { get; set; }

    public int PostId { get; set; }

    public int UserId { get; set; }

    public int Score { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
