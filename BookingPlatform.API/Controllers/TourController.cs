using BookingPlatform.Application.Interfaces;
using BookingPlatform.Core.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingPlatform.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TourController : ControllerBase
    {
        private readonly ITourService _tourService;

        public TourController(ITourService tourService)
        {
            _tourService = tourService;
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public async Task<IActionResult> CreateTour([FromBody] CreateTourRequest request)
        {
            await _tourService.CreateTour(request);

            return Ok();
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetTours()
        {
            var response = _tourService.GetTours();

            return Ok(response);
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut]
        public async Task<IActionResult> UpdateTour(int id, [FromBody] UpdateTourRequest updateRequest)
        {
            await _tourService.UpdateTour(id, updateRequest);

            return Ok();
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTour(int id)
        {
            await _tourService.DeleteTour(id);

            return Ok();
        }
    }
}
