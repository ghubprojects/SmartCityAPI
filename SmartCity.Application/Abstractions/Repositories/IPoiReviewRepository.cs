using SmartCity.Domain.Entities;

namespace SmartCity.Application.Abstractions.Repositories;

public interface IPoiReviewRepository {
    Task<List<PoiReview>> GetReviewsByPoiGidAsync(int poiGid);
    Task AddReviewAsync(PoiReview review);
    Task UpdateReviewAsync(PoiReview review);
    Task DeleteReviewAsync(int reviewId);
}