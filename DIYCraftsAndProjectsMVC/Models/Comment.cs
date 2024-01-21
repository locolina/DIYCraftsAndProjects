using System;
using System.Collections.Generic;

namespace DIYCraftsAndProjectsMVC.Models;

public partial class Comment
{
    public int CommentId { get; set; }

    public int PostId { get; set; }

    public string Comment1 { get; set; } = null!;

    public int? ParentId { get; set; }

    public int UserId { get; set; }

    public DateTime? Posted { get; set; }

    public bool Highlighted { get; set; }

    public bool Reported { get; set; }

    public virtual ICollection<Comment> InverseParent { get; set; } = new List<Comment>();

    public virtual Comment? Parent { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
