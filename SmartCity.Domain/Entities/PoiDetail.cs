using SmartCity.Domain.Common.Entities;

namespace SmartCity.Domain.Entities;

#pragma warning disable

public partial class PoiDetail : BaseEntity {
    public int DetailId { get; set; }

    public int PoiGid { get; set; }

    public string Description { get; set; }

    public string OpeningHours { get; set; }

    public virtual ICollection<PoiPhoto> PoiPhotos { get; set; } = new List<PoiPhoto>();

    public virtual ICollection<PoiReview> PoiReviews { get; set; } = new List<PoiReview>();
}
