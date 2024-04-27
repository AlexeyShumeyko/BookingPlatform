using System.ComponentModel.DataAnnotations;

namespace BookingPlatform.Core.Request
{
    public record CreateTourRequest(
        [Required] string Name,
        [Required] string Description,
        [Required] string Location,
        [Required] DateTime StartDate,
        [Required] DateTime EndDate,
        [Required] decimal Price,
        [Required] int MaxCapacity);
}
