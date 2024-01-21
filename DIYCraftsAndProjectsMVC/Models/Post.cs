using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DIYCraftsAndProjectsMVC.Models;

public partial class Post
{
    public int PostId { get; set; }

    public int UserId { get; set; }

    public bool Public { get; set; }

    public DateTime? DatePosted { get; set; }

    public DateTime? DateDeleted { get; set; }

    public int? Views { get; set; }

    public decimal? Score { get; set; }

    public string? Title { get; set; }

    public string? FileType { get; set; }

    public byte[]? Content { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<PostScore> PostScores { get; set; } = new List<PostScore>();

    public virtual User User { get; set; } = null!;
}