using System;
using System.Collections.Generic;

#nullable disable

namespace SmartCity.Domain.Entities;

public partial class TPlacePhoto {
    public int PhotoId { get; set; }

    public int DetailId { get; set; }

    public int FileId { get; set; }

    public string Caption { get; set; }

    public DateTime CreatedDate { get; set; }

    public string CreatedBy { get; set; }

    public DateTime LastModifiedDate { get; set; }

    public string LastModifiedBy { get; set; }

    public bool DeleteFlag { get; set; }

    public virtual MPlaceDetail Detail { get; set; } = null!;

    public virtual MFile File { get; set; } = null!;
}
