using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingPlatform.Core.Request
{
    public record CreateReviewRequest(
        [Required] int Rating,
        string Comment
        );
}
