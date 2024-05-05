using BookingPlatform.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BookingPlatform.DAL.Configurations
{
    public class ReviewDbConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        { 
            //builder.HasKey(r => r.Id);

            builder.HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(u => u.UserId);

            builder.HasOne(r => r.Tour)
                .WithMany(t => t.Reviews)
                .HasForeignKey(r => r.TourId);
        }
            
    }
}
