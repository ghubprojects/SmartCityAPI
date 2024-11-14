using SmartCity.Application.DTOs;

namespace SmartCity.Application.Abstractions.Services;

public interface IPlaceService {
    Task<List<PlaceDetailDto>> GetPlacesNearLocationAsync(double lat, double lon, string type, double distance);
}