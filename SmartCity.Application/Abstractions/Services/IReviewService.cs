namespace SmartCity.Application.Abstractions.Services;

public interface IReviewService {
    Task AddReviewAsync(int placeId, int userId, int rating, string comment);
}