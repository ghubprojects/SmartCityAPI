using SmartCity.Application.DTOs;

namespace SmartCity.Application.Abstractions.Services;

public interface IPlaceService {
    Task<List<PlaceDetailDto>> GetPlacesAsync(string? type, string? area, double lat, double lon, double distance);
    Task<List<string>> GetTypesAsync();
}