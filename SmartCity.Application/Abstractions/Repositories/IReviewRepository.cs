using SmartCity.Domain.Entities;

namespace SmartCity.Application.Abstractions.Repositories;

public interface IReviewRepository {
    Task AddReviewAsync(TPlaceReview review);
}