using BookingPlatform.Application.Interfaces;
using BookingPlatform.Core.Contract;
using BookingPlatform.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace BookingPlatform.Application.Services
{
    public class ReservationReporting : IReservationReporting
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReservationReporting(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public byte[] GenerateTourReport()
        {
            var repo = _unitOfWork.GetRepository<ReservationTour>();

            var reservationTour = repo.AsQueryable()
                .Include(rt => rt.Tour)
                .ToList();

            var report = reservationTour
                .GroupBy(rt => rt.Tour)
                .Select(group => new
                {
                    Tour = group.Key,
                    ParticipantCount = group.Count()
                })
            .ToList();

            var reportText = new StringBuilder("Excursion Name, Participant Count\n");

            foreach (var item in report)
            {
                reportText.Append($"{item.Tour.Name} {item.ParticipantCount}\n");
            }

            return Encoding.UTF8.GetBytes(reportText.ToString());
        }
    }
}
