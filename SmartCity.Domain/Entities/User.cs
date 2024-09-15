using SmartCity.Domain.Common.Entities;

namespace SmartCity.Domain.Entities;

#pragma warning disable

public partial class User : BaseEntity {
    public int UserId { get; set; }

    public string Username { get; set; }

    public string Email { get; set; }

    public string PasswordHash { get; set; }

    public virtual ICollection<PoiReview> PoiReviews { get; set; } = new List<PoiReview>();
}
