using AutoMapper;
using SmartCity.Domain.Entities;

namespace SmartCity.Application.DTOs;

public class PoiDetailDto {
    public string Description { get; set; } = string.Empty;

    public string OpeningHours { get; set; } = string.Empty;

    public List<PoiPhoto> Photos { get; set; } = [];

    public List<PoiReview> Reviews { get; set; } = [];
}

public class PoiDetailDtoMappingProfile : Profile {
    public PoiDetailDtoMappingProfile() {
        CreateMap<PoiDetail, PoiDetailDto>()
            .ForMember(dest => dest.Photos, opt => opt.MapFrom(src => src.PoiPhotos))
            .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.PoiReviews))
            .ReverseMap();
    }
}
