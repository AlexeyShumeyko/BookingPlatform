using BookingPlatform.Core.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BookingPlatform.Core.Models
{
    public class Tour : Entity<int>
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Location { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public required decimal Price { get; set; }
        public required int MaxCapacity { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
