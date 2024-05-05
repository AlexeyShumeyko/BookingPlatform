using BookingPlatform.Core.Models;

namespace BookingPlatform.Application.Interfaces
{
    public interface IReviewService
    {
        public Task AddReview(string claimUserId, int tourId, int rating, string comment);

        public Task AddReview(string claimUserId, int tourId, int rating);

        public IEnumerable<Review> GetTourReviews(int tourId);
    }
}
