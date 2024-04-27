using BookingPlatform.Core.Contract;

namespace BookingPlatform.Core.Request
{
    public record UpdateTourRequest(
        string Name,
        string Description,
        string Location,
        DateTime StartDate,
        DateTime EndDate,
        decimal Price,
        int MaxCapacity) : IRequest;
}
