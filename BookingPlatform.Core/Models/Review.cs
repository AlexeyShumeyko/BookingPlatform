using BookingPlatform.Core.Contract;
using BookingPlatform.Core.Identity;

namespace BookingPlatform.Core.Models
{
    public class Review : Entity<int>
    {
        public string Comment { get; set; } = string.Empty;
        public required int Rating { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int TourId { get; set; }
        public Tour Tour { get; set; }

    }
}
