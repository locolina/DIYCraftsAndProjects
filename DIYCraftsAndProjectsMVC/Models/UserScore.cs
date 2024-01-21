using System;
using System.Collections.Generic;

namespace DIYCraftsAndProjectsMVC.Models;

public partial class UserScore
{
    public int UserScoreId { get; set; }

    public int UserId { get; set; }

    public int UserIdScorer { get; set; }

    public int Score { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual User UserIdScorerNavigation { get; set; } = null!;
}
