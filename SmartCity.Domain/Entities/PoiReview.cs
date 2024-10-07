using SmartCity.Domain.Common.Entities;

namespace SmartCity.Domain.Entities;

#nullable disable

public partial class PoiReview : BaseEntity {
    public int ReviewId { get; set; }

    public int DetailId { get; set; }

    public int UserId { get; set; }

    public int Rating { get; set; }

    public string Comment { get; set; }

    public virtual PoiDetail Detail { get; set; }

    public virtual User User { get; set; }
}
