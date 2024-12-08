using MongoDB.Driver.GeoJsonObjectModel;
using SmartCity.Domain.Constants;
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
    public int OpeningStatus { get; set; }
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
        OpeningStatus = GetOpeningStatus(mPlaceDetail.OpeningHours);
        Longitude = GetLongitude(poi.Geometry);
        Latitude = GetLatitude(poi.Geometry);
        Rating = Math.Round(mPlaceDetail.TPlaceReviews.Average(x => x.Rating), 1);
        Photos = mPlaceDetail.TPlacePhotos.Select(x => new PlacePhotoDto(x)).ToList();
        Reviews = mPlaceDetail.TPlaceReviews.Select(x => new PlaceReviewDto(x)).ToList();
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

    private static int GetOpeningStatus(string openingHours) {
        if (string.IsNullOrWhiteSpace(openingHours)) {
            return Consts.OpeningStatus.Unknown;
        }

        if (openingHours.Trim() == "24/7") {
            return Consts.OpeningStatus.AlwaysOpen;
        }

        var hours = openingHours.Split('-');
        if (hours.Length == 2) {
            if (TimeSpan.TryParse(hours[0], out var openTime) &&
                TimeSpan.TryParse(hours[1], out var closeTime)) {
                var now = DateTime.Now.TimeOfDay;
                return (now >= openTime && now < closeTime) ? Consts.OpeningStatus.Open : Consts.OpeningStatus.Closed;
            }
        }

        return Consts.OpeningStatus.Unknown;
    }

}