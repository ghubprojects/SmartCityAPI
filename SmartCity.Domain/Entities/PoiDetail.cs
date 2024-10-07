using SmartCity.Domain.Common.Entities;

namespace SmartCity.Domain.Entities;

#nullable disable

public partial class PoiDetail : BaseEntity {
    public int DetailId { get; set; }

    public string OsmId { get; set; }

    public string Description { get; set; }

    public string OpeningHours { get; set; }

    public virtual ICollection<PoiPhoto> PoiPhotos { get; set; } = [];

    public virtual ICollection<PoiReview> PoiReviews { get; set; } = [];
}
