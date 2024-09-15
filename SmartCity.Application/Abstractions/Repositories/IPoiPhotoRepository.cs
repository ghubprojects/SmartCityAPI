using SmartCity.Domain.Entities;

namespace SmartCity.Application.Abstractions.Repositories;

public interface IPoiPhotoRepository {
    Task<List<PoiPhoto>> GetPhotosByPoiGidAsync(int poiGid);
    Task AddPhotoAsync(PoiPhoto photo);
    Task UpdatePhotoAsync(PoiPhoto photo);
    Task DeletePhotoAsync(int photoId);
}