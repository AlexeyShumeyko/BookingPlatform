using BookingPlatform.Application.Interfaces;
using BookingPlatform.Core.Contract;
using BookingPlatform.Core.Models;
using BookingPlatform.Core.Request;
using BookingPlatform.Core.Response;
using Microsoft.EntityFrameworkCore;
using ILogger = Serilog.ILogger;

namespace BookingPlatform.Application.Services
{
    public class TourService : ITourService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public TourService(IUnitOfWork unitOfWork, ILogger logger) 
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task CreateTour(CreateTourRequest request)
        {
            var repo = _unitOfWork.GetRepository<Tour>();

            var tour = new Tour()
            {
                Name = request.Name,
                Description = request.Description,
                Location = request.Location,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Price = request.Price,
                MaxCapacity = request.MaxCapacity,
                Reviews = new List<Review>()
            };

            repo.Create(tour);

            await _unitOfWork.SaveChangesAsync();
        }

        public IQueryable<GetTourResponse> GetTours()
        {
            var repo = _unitOfWork.GetRepository<Tour>();

            var tours = repo.AsQueryable();

            var response = tours
                .Select(t => new GetTourResponse(
                    t.Id, t.Name, t.Description, t.Location,
                    t.StartDate, t.EndDate, t.Price, t.MaxCapacity));

            return response;
        }

        public async Task UpdateTour(int id, UpdateTourRequest request)
        {
            var repo = _unitOfWork.GetRepository<Tour>();

            var tour = await repo.AsQueryable()
                .FirstOrDefaultAsync(t => t.Id == id);

            if (tour != null)
            {
                repo.Update(tour, request);

                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task DeleteTour(int id)
        {
            var repo = _unitOfWork.GetRepository<Tour>();

            var tour = repo.AsQueryable()
                .FirstOrDefaultAsync(t => t.Id == id).Result;
            
            if (tour != null)
            {
                repo.Delete(tour);

                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
