using SmartCity.Application.DTOs;

namespace SmartCity.Application.Abstractions.Services;

public interface IPoiService {
    Task<List<PoiDetailDto>> GetPoisNearLocation(double lat, double lon, double distance);
}