using SmartCity.Domain.Entities;

namespace SmartCity.Application.Abstractions.Repositories;

public interface IPoiDetailRepository {
    Task<List<PoiDetail>> GetPoiDetailsByGidsAsync(List<int> poiGids);
    Task<PoiDetail?> GetPoiDetailsByGidAsync(int poiGid);
    Task UpdatePoiDetailsAsync(PoiDetail poiDetails);
    Task DeletePoiDetailsAsync(int poiGid);
}