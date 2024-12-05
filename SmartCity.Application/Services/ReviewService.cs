using Microsoft.AspNetCore.Http;
using SmartCity.Application.Abstractions.Repositories;
using SmartCity.Application.Abstractions.Services;
using SmartCity.Domain.Entities;

namespace SmartCity.Application.Services;

public class ReviewService(
    IReviewRepository reviewRepository,
    IPlaceDetailRepository placeDetailRepository, 
    IUserRepository userRepository) : IReviewService {
    private readonly IReviewRepository _reviewRepository = reviewRepository;
    private readonly IPlaceDetailRepository _placeDetailRepository = placeDetailRepository;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task AddReviewAsync(int placeId, int userId, int rating, string comment) {
        var isPlaceExist = await _placeDetailRepository.IsExistAsync(placeId);
        if (!isPlaceExist) {
            throw new BadHttpRequestException("Địa điểm không tồn tại.");
        }

       var isUserExist = await _userRepository.IsExistAsync(userId);
        if (!isUserExist) {
            throw new BadHttpRequestException("Người dùng không tồn tại.");
        }

        var newReview = new TPlaceReview {
            DetailId = placeId,
            UserId = userId,
            Rating = rating,
            Comment = comment
        };
        await _reviewRepository.AddReviewAsync(newReview);
    }
}
