using System;
using System.Collections.Generic;

namespace DIYCraftsAndProjectsMVC.Models;

public partial class UploadedFile
{
    public int IdUploadedFile { get; set; }

    public string FileName { get; set; } = null!;

    public string FileType { get; set; } = null!;

    public byte[] FileContent { get; set; } = null!;

    public int? PostId { get; set; }

    public virtual Post? Post { get; set; }
}
