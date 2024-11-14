using AutoMapper;
using MongoDB.Driver.GeoJsonObjectModel;
using SmartCity.Domain.Entities;
using SmartCity.Domain.Entities.GisOsm;

namespace SmartCity.Application.DTOs;

public class PlaceDetailDto {
    public string DetailId { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public string Description { get; set; } = string.Empty;
    public string OpeningHours { get; set; } = string.Empty;
    public List<PlacePhotoDto> Photos { get; set; } = new();
    public List<PlaceReviewDto> Reviews { get; set; } = new();
}

public class PlacePhotoDto {
    public int PhotoId { get; set; }
    public string Caption { get; set; } = string.Empty;
    public int FileId { get; set; } // Reference ID only, not full File object
}

public class PlaceReviewDto {
    public int ReviewId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public int UserId { get; set; } // Reference ID only, not full User object
}

public class PlaceDetailDtoMappingProfile : Profile {
    public PlaceDetailDtoMappingProfile() {
        //CreateMap<Poi, PlaceDetailDto>()
        //    .ForMember(dest => dest.DetailId, otp => otp.MapFrom(src => src.Properties.OsmId))
        //    .ForMember(dest => dest.Type, otp => otp.MapFrom(src => src.Properties.Fclass))
        //    .ForMember(dest => dest.Name, otp => otp.MapFrom(src => src.Properties.Name))
        //    .ForMember(dest => dest.Latitude, otp => otp.MapFrom(src => GetLatitude(src.Geometry)))
        //    .ForMember(dest => dest.Longitude, otp => otp.MapFrom(src => GetLongitude(src.Geometry)))
        //    .ReverseMap();

        //CreateMap<MPlaceDetail, PlaceDetailDto>()
        //    .ForMember(dest => dest.Description, otp => otp.MapFrom(src => src.Description))
        //    .ForMember(dest => dest.OpeningHours, otp => otp.MapFrom(src => src.OpeningHours))
        //    .ForMember(dest => dest.Photos, opt => opt.MapFrom(src => src.TPlacePhotos.Select(x => new PlacePhotoDto() { })))
        //    .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.TPlaceReviews.Select(x => new PlaceReviewDto() { })))
        //    .ReverseMap();

        CreateMap<Poi, PlaceDetailDto>()
            .ForMember(dest => dest.DetailId, otp => otp.MapFrom(src => src.Properties.OsmId))
            .ForMember(dest => dest.Type, otp => otp.MapFrom(src => src.Properties.Fclass))
            .ForMember(dest => dest.Name, otp => otp.MapFrom(src => src.Properties.Name))
            .ForMember(dest => dest.Latitude, otp => otp.MapFrom(src => GetLatitude(src.Geometry)))
            .ForMember(dest => dest.Longitude, otp => otp.MapFrom(src => GetLongitude(src.Geometry)))
            .ReverseMap();

        CreateMap<MPlaceDetail, PlaceDetailDto>()
            .ForMember(dest => dest.Description, otp => otp.MapFrom(src => src.Description))
            .ForMember(dest => dest.OpeningHours, otp => otp.MapFrom(src => src.OpeningHours))
            .ForMember(dest => dest.Photos, opt => opt.MapFrom(src => src.TPlacePhotos.Select(x => new PlacePhotoDto {
                PhotoId = x.PhotoId,
                Caption = x.Caption,
                FileId = x.FileId // Only reference ID
            })))
            .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.TPlaceReviews.Select(x => new PlaceReviewDto {
                ReviewId = x.ReviewId,
                Rating = x.Rating,
                Comment = x.Comment,
                UserId = x.UserId // Only reference ID
            })))
            .ReverseMap();
    }

    private static double GetLatitude(GeoJsonGeometry<GeoJson2DCoordinates> geometry) => geometry switch {
        GeoJsonPoint<GeoJson2DCoordinates> point => point.Coordinates.Y,
        GeoJsonPolygon<GeoJson2DCoordinates> polygon => polygon.Coordinates.Exterior.Positions.First().Y,
        _ => 0 // Default value for unsupported geometry types
    };

    private static double GetLongitude(GeoJsonGeometry<GeoJson2DCoordinates> geometry) => geometry switch {
        GeoJsonPoint<GeoJson2DCoordinates> point => point.Coordinates.X,
        GeoJsonPolygon<GeoJson2DCoordinates> polygon => polygon.Coordinates.Exterior.Positions.First().X,
        _ => 0 // Default value for unsupported geometry types
    };
}
