using System;
using System.Collections.Generic;

#nullable disable

namespace SmartCity.Domain.Entities;

public partial class MPlaceDetail {
    public int DetailId { get; set; }

    public string OsmId { get; set; } = null!;

    public string Description { get; set; }

    public string OpeningHours { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime LastModifiedDate { get; set; }

    public int LastModifiedBy { get; set; }

    public bool DeleteFlag { get; set; }

    public virtual ICollection<TPlacePhoto> TPlacePhotos { get; set; } = new List<TPlacePhoto>();

    public virtual ICollection<TPlaceReview> TPlaceReviews { get; set; } = new List<TPlaceReview>();
}
