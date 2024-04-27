namespace BookingPlatform.Application.Interfaces
{
    public interface IUserService
    {
        public Task Register(string userName, string email, string password);
        public Task<string> Login(string emeil, string password);
    }
}