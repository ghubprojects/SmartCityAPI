using SmartCity.Domain.Common.Entities;
using SmartCity.Domain.Entities;

namespace SmartCity.Application.Features.Pois.DTOs;
public class PoiDetailDto : IEntityMapper<PoiDetail> {
    public string Description { get; set; }

    public string OpeningHours { get; set; }

    public List<PoiPhoto> Photos { get; set; }

    public List<PoiReview> Reviews { get; set; }

    public PoiDetailDto(PoiDetail detail) {
        Description = detail.Description;
        OpeningHours = detail.OpeningHours;
        Photos = [.. detail.PoiPhotos];
        Reviews = [.. detail.PoiReviews];
    }

    public PoiDetail ToEntity() {
        throw new NotImplementedException();
    }
}
