using BookingPlatform.Application.Interfaces;
using BookingPlatform.Core.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookingPlatform.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateReview(int tourId, [FromBody] CreateReviewRequest request)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return BadRequest();
            }

            if(request.Comment == null)
            {
                await _reviewService.AddReview(userId, tourId, request.Rating);

                return Ok();
            }

            await _reviewService.AddReview(userId, tourId, request.Rating, request.Comment);

            return Ok();
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetTourReviews(int tourId)
        {
            var reviews = _reviewService.GetTourReviews(tourId);

            return Ok(reviews);
        }
    }
}
