using System;
using System.Collections.Generic;

namespace DIYCraftsAndProjectsMVC.Models;

public partial class UserFollowUser
{
    public int IdUserFollowUser { get; set; }

    public int UserFollowingId { get; set; }

    public int UserFollowedId { get; set; }

    public virtual User UserFollowed { get; set; } = null!;

    public virtual User UserFollowing { get; set; } = null!;
}
