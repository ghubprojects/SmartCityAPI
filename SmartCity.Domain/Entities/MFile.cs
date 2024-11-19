using System;
using System.Collections.Generic;

#nullable disable

namespace SmartCity.Domain.Entities;

public partial class MFile {
    public int FileId { get; set; }

    public string FileName { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastModifiedDate { get; set; }

    public string LastModifiedBy { get; set; }

    public bool DeleteFlag { get; set; }

    public virtual ICollection<MUser> MUsers { get; set; } = new List<MUser>();

    public virtual ICollection<TPlacePhoto> TPlacePhotos { get; set; } = new List<TPlacePhoto>();
}
