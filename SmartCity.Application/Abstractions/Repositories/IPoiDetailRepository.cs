using SmartCity.Domain.Entities;

namespace SmartCity.Application.Abstractions.Repositories;

public interface IPlaceDetailRepository {
    Task<List<MPlaceDetail>> GetDataListAsync(List<string> osmIds);
    Task<MPlaceDetail?> GetDataAsync(string osmId);
    Task<bool> IsExistAsync(int detailId);
}