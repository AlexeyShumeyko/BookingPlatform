using BookingPlatform.Core.Models;

namespace BookingPlatform.Application.Interfaces
{
    public interface IReservationService
    {
        public Task Reservation(int tourId, string claimUserId);

        public IEnumerable<ReservationTour> GetUserReservations(string claimUserId);

        public IEnumerable<ReservationTour> GetTourReservations(int tourId);
    }
}
