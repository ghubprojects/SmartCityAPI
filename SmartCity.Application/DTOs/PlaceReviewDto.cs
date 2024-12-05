
using SmartCity.Domain.Entities;

namespace SmartCity.Application.DTOs;

public class PlaceReviewDto {
    public int ReviewId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string UserAvatar { get; set; } = string.Empty;
    public DateTime LastModifiedDate { get; set; }
    public PlaceReviewDto(TPlaceReview review) {
        ReviewId = review.ReviewId;
        Rating = review.Rating;
        Comment = review.Comment;
        UserName = review.User.Username;
        UserAvatar = review.User.Avatar.FileName;
        LastModifiedDate = review.LastModifiedDate;
    }
}