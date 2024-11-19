using SmartCity.Application.DTOs;

namespace SmartCity.Application.Abstractions.Services;

public interface IPlaceService {
    Task<List<PlaceDetailDto>> GetPlacesAsync(string keyword, double lat, double lon, double distance);
}