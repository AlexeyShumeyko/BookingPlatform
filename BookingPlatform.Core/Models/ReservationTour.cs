using BookingPlatform.Core.Contract;
using BookingPlatform.Core.Identity;

namespace BookingPlatform.Core.Models
{
    public class ReservationTour : Entity<int>
    {
        public DateTime? ReservationDate { get; set; }

        public int TourId { get; set; }
        public Tour Tour { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
