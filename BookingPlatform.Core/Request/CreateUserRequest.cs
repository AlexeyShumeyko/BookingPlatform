using System.ComponentModel.DataAnnotations;

namespace BookingPlatform.Core.Request
{
    public record CreateUserRequest(

        [Required]
        [StringLength(20)]
        string UserName,

        [Required]
        [EmailAddress]
        string Email,

        [Required]
        string Password
        );
}
