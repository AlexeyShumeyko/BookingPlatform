using BookingPlatform.Core.Request;
using BookingPlatform.Core.Response;

namespace BookingPlatform.Application.Interfaces
{
    public interface ITourService
    {
        public Task CreateTour(CreateTourRequest request);

        public IQueryable<GetTourResponse> GetTours();

        public Task UpdateTour(int id, UpdateTourRequest request);

        public Task DeleteTour(int id);
    }
}
