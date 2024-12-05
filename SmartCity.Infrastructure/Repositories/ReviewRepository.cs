using SmartCity.Application.Abstractions.Repositories;
using SmartCity.Domain.Entities;
using SmartCity.Infrastructure.DataContext;

namespace SmartCity.Infrastructure.Repositories;

public class ReviewRepository(AppDbContext context) : IReviewRepository {
    private readonly AppDbContext _context = context;

    public async Task AddReviewAsync(TPlaceReview review) {
        _context.TPlaceReviews.Add(review);
        await _context.SaveChangesAsync();
    }
}