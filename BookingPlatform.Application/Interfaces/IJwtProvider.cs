using BookingPlatform.Core.Identity;

namespace BookingPlatform.Application.Interfaces
{
    public interface IJwtProvider
    {
        public string GenerateToken(User user);
    }
}
