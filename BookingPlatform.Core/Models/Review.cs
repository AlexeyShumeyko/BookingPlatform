using BookingPlatform.Core.Contract;
using BookingPlatform.Core.Identity;

namespace BookingPlatform.Core.Models
{
    public class Review : Entity<int>
    {
        public string Comment { get; set; } = string.Empty;
        public int Rating { get; set; }
        public required User User { get; set; }
        public required Tour Tour { get; set; }

    }
}
