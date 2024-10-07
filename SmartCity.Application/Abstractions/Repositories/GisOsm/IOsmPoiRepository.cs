using SmartCity.Domain.Entities.GisOsm;

namespace SmartCity.Application.Abstractions.Repositories.GisOsm;

public interface IOsmPoiRepository {
    Task<List<OsmPoi>> GetNearSphereAsync(double latitude, double longitude, double radius);
}
