using System;
using System.Collections.Generic;

namespace DIYCraftsAndProjectsMVC.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string Email { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public int CountryId { get; set; }

    public int TypeId { get; set; }

    public DateTime DateCreated { get; set; }

    public bool IsActive { get; set; }

    public string Password { get; set; } = null!;

    public decimal? Score { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<Notification> NotificationSenders { get; set; } = new List<Notification>();

    public virtual ICollection<Notification> NotificationUsers { get; set; } = new List<Notification>();

    public virtual ICollection<PostScore> PostScores { get; set; } = new List<PostScore>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual ICollection<Report> ReportReporteds { get; set; } = new List<Report>();

    public virtual ICollection<Report> ReportReportings { get; set; } = new List<Report>();

    public virtual TypeOfUser Type { get; set; } = null!;

    public virtual ICollection<UserFollowUser> UserFollowUserUserFolloweds { get; set; } = new List<UserFollowUser>();

    public virtual ICollection<UserFollowUser> UserFollowUserUserFollowings { get; set; } = new List<UserFollowUser>();

    public virtual ICollection<UserScore> UserScoreUserIdScorerNavigations { get; set; } = new List<UserScore>();

    public virtual ICollection<UserScore> UserScoreUsers { get; set; } = new List<UserScore>();
}
