using BookingPlatform.Core.Contract;
using BookingPlatform.Core.Models;

namespace BookingPlatform.Core.Identity
{
    public class User : Entity<int>
    {
        private User(string userName, string passwordHash, string email) 
        { 
            UserName = userName;
            PasswordHash = passwordHash;
            Email = email;
        }

        public string UserName { get; private set; }

        public string PasswordHash { get; private set; }

        public string Email { get; private set; }

        public string Role { get; set; } = string.Empty;

        public ICollection<Review> Reviews { get; set; }
        public ICollection<ReservationTour> ReservationTours { get; set; }

        public static User Create (string userName, string passwordHash, string email)
        {
            return new User (userName, passwordHash, email);
        }
    }
}
