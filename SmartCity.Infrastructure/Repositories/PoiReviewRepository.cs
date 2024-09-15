using Microsoft.EntityFrameworkCore;
using SmartCity.Application.Abstractions.Repositories;
using SmartCity.Domain.Entities;
using SmartCity.Infrastructure.DataContext;

namespace SmartCity.Infrastructure.Repositories;

public class PoiReviewRepository(SmartCityContext context) : IPoiReviewRepository {
    private readonly SmartCityContext _context = context;

    public async Task<List<PoiReview>> GetReviewsByPoiGidAsync(int poiGid) {
        return await _context.PoiReviews
            .Where(x => x.DetailId.Equals(poiGid) && !x.DeleteFlag)
            .ToListAsync();
    }

    public async Task AddReviewAsync(PoiReview review) {
        _context.PoiReviews.Add(review);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateReviewAsync(PoiReview review) {
        _context.PoiReviews.Update(review);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteReviewAsync(int reviewId) {
        var review = await _context.PoiReviews.FindAsync(reviewId);
        if (review != null) {
            review.DeleteFlag = true;
            await _context.SaveChangesAsync();
        }
    }
}
