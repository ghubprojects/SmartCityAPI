using MongoDB.Driver.GeoJsonObjectModel;
using SmartCity.Domain.Entities;
using SmartCity.Domain.Entities.GisOsm;

namespace SmartCity.Application.DTOs;

public class PlaceDetailDto {
    public int DetailId { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string OpeningHours { get; set; } = string.Empty;
    public double Longitude { get; set; }
    public double Latitude { get; set; }
    public double Rating { get; set; }
    public List<PlacePhotoDto> Photos { get; set; } = [];
    public List<PlaceReviewDto> Reviews { get; set; } = [];

    public PlaceDetailDto(Poi poi, MPlaceDetail mPlaceDetail, Dictionary<string, string> placeTypeDict) {
        DetailId = mPlaceDetail.DetailId;
        Type = placeTypeDict.GetValueOrDefault(poi.Properties.Fclass) ?? string.Empty;
        Name = poi.Properties.Name;
        Description = mPlaceDetail.Description;
        Address = mPlaceDetail.Address;
        OpeningHours = mPlaceDetail.OpeningHours;
        Longitude = GetLongitude(poi.Geometry);
        Latitude = GetLatitude(poi.Geometry);
        Rating = Math.Round(mPlaceDetail.TPlaceReviews.Average(x => x.Rating), 1);

        Photos = mPlaceDetail.TPlacePhotos.Select(x => new PlacePhotoDto {
            PhotoId = x.PhotoId,
            Caption = x.Caption,
            FileName = x.File.FileName,
            FilePath = x.File.FilePath
        }).ToList();
        Reviews = mPlaceDetail.TPlaceReviews.Select(x => new PlaceReviewDto {
            ReviewId = x.ReviewId,
            Rating = x.Rating,
            Comment = x.Comment,
            UserName = x.User.Username,
            UserAvatar = x.User.Avatar.FileName,
            CreatedDate = x.CreatedDate,
        }).ToList();
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

public class PlacePhotoDto {
    public int PhotoId { get; set; }
    public string Caption { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
}

public class PlaceReviewDto {
    public int ReviewId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string UserAvatar { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
}