using SmartCity.Domain.Entities.GisOsm;

namespace SmartCity.Application.Abstractions.Repositories.GisOsm;

public interface IPoiRepository {
    Task<List<Poi>> GetNearSphereAsync(double latitude, double longitude, string type, double radius);
}
