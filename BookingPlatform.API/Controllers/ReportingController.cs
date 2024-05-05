using BookingPlatform.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingPlatform.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ReportingController : ControllerBase
    {
        private readonly IReservationReporting _reservationReporting;

        public ReportingController(IReservationReporting reservationReporting)
        {
            _reservationReporting = reservationReporting;
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet]
        public IActionResult GenerateTourReport() 
        {
            var reportBytes = _reservationReporting.GenerateTourReport();

            return File(reportBytes, "text/csv", "TourReport.csv");
        }
    }
}
