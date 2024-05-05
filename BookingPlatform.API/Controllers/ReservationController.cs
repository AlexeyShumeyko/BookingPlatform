using BookingPlatform.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookingPlatform.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ReserveTour(int tourId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return BadRequest();
            }

            await _reservationService.Reservation(tourId, userId);

            return Ok();
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetUsersReservations()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return BadRequest();
            }

            var list = _reservationService.GetUserReservations(userId);

            return Ok(list);
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet]
        public IActionResult GetTourReservations(int tourId)
        {
            var list = _reservationService.GetTourReservations(tourId);

            return Ok(list);
        }
    }
}
