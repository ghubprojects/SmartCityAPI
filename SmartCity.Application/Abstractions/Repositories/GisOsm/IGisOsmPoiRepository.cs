using SmartCity.Domain.Entities.GisOsm;

namespace SmartCity.Application.Abstractions.Repositories.GisOsm;

public interface IGisOsmPoiRepository {
    Task<List<GisOsmPoi>> GetPoisNearLocation(double latitude, double longitude, double radius);
}
