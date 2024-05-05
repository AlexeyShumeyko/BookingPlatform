using BookingPlatform.Core.Contract;

namespace BookingPlatform.Core.Models
{
    public class Tour : Entity<int>
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Location { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public required decimal Price { get; set; }
        public required int MaxCapacity { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<ReservationTour> ReservationTour {  get; set; }
    }
}
