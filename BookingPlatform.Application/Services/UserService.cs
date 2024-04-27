using BookingPlatform.Core.Contract;
using ILogger = Serilog.ILogger;
using BookingPlatform.Core.Identity;
using Microsoft.EntityFrameworkCore;
using BookingPlatform.Application.Interfaces;

namespace BookingPlatform.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;

        public UserService(
            IUnitOfWork unitOfWork,
            ILogger logger,
            IPasswordHasher passwordHasher,
            IJwtProvider jwtProvider)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
        }

        public async Task Register(string userName, string email, string password)
        {
            var hashedPassword = _passwordHasher.Generate(password);

            var userRepo = _unitOfWork.GetRepository<User>();

            var user = User.Create(userName, hashedPassword, email);

            user.Role = "User";

            userRepo.Create(user);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<string> Login (string email, string password)
        {
            var repo = _unitOfWork.GetRepository<User>();

            var user = await repo.AsQueryable()
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == email) ?? throw new Exception();

            var result = _passwordHasher.Verify(password, user.PasswordHash);

            var token = _jwtProvider.GenerateToken(user);

            return token;
        }
    }
}
