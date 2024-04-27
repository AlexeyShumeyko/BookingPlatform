using System.ComponentModel.DataAnnotations;

namespace BookingPlatform.Core.Response
{
    public record GetTourResponse(
        [Required] int Id,
        [Required] string Name,
        [Required] string Description,
        [Required] string Location,
        [Required] DateTime StartDate,
        [Required] DateTime EndDate,
        [Required] decimal Price,
        [Required] int MaxCapacity);
}
