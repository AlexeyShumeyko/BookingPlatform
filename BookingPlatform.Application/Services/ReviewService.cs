using BookingPlatform.Application.Interfaces;
using BookingPlatform.Core.Contract;
using BookingPlatform.Core.Models;

namespace BookingPlatform.Application.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReviewService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddReview(string claimUserId, int tourId, int rating, string comment)
        {
            var repo = _unitOfWork.GetRepository<Review>();

            var userId = Convert.ToInt32(claimUserId);

            var review = new Review()
            {
                UserId = userId,
                TourId = tourId,
                Rating = rating,
                Comment = comment
            };

            repo.Create(review);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task AddReview(string claimUserId, int tourId, int rating)
        {
            var repo = _unitOfWork.GetRepository<Review>();

            var userId = Convert.ToInt32(claimUserId);

            var review = new Review
            {
                UserId = userId,
                TourId = tourId,
                Rating = rating
            };

            repo.Create(review);

            await _unitOfWork.SaveChangesAsync();
        }

        public IEnumerable<Review> GetTourReviews(int tourId)
        {
            var repo = _unitOfWork.GetRepository<Review>();

            var listTourReviews = repo
                .AsQueryable()
                .Where(r => r.TourId == tourId)
                .ToList();

            return listTourReviews;
        }
    }
}
