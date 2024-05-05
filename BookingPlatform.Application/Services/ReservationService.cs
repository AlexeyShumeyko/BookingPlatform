using BookingPlatform.Application.Interfaces;
using BookingPlatform.Core.Contract;
using BookingPlatform.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingPlatform.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReservationService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Reservation (int tourId, string claimUserId)
        {
            var tourRepo = _unitOfWork.GetRepository<Tour>();
            var reservationRepo = _unitOfWork.GetRepository<ReservationTour>();

            var tour = await tourRepo.AsQueryable()
                .FirstOrDefaultAsync(t => t.Id == tourId);

            var userId = Convert.ToInt32(claimUserId);

            var reservationTour = new ReservationTour
            {
                TourId = tourId,
                UserId = userId,
                ReservationDate = DateTime.Now
            };

            reservationRepo.Create(reservationTour);

            await _unitOfWork.SaveChangesAsync();
        }

        public IEnumerable<ReservationTour> GetUserReservations(string claimUserId)
        {
            var reservationRepo = _unitOfWork.GetRepository<ReservationTour>();

            var userId = Convert.ToInt32(claimUserId);

            var listUserReservation = reservationRepo
                .AsQueryable()
                .Where(rt => rt.UserId == userId)
                .ToList();

            return listUserReservation;
        }

        public IEnumerable<ReservationTour> GetTourReservations(int tourId)
        {
            var reservationRepo = _unitOfWork.GetRepository<ReservationTour>();

            var listTourReservation = reservationRepo
                .AsQueryable()
                .Where(rt => rt.TourId == tourId)
                .ToList();

            return listTourReservation;
        }

        //public List<ReservationTour> GetUsersReservationTour()
        //{
        //    var repo = _unitOfWork.GetRepository<ReservationTour>();

        //    var listReservationTour = repo.AsQueryable()
        //        .Include(rt => rt.Tour)
        //        .Include(rt => rt.User)
        //        .ToList();

        //    return listReservationTour;
        //}
    }
}
