using SmartCity.Domain.Entities;

namespace SmartCity.Application.Abstractions.Repositories;

public interface IPoiDetailRepository {
    Task<List<PoiDetail>> GetDataListAsync(List<string> osmIds);
    Task<PoiDetail?> GetDataAsync(string osmId);
}