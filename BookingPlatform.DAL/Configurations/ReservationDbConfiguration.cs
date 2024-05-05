using BookingPlatform.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingPlatform.DAL.Configurations
{
    public class ReservationDbConfiguration : IEntityTypeConfiguration<ReservationTour>
    {
        public void Configure(EntityTypeBuilder<ReservationTour> builder)
        {
            //builder.HasKey(rt => rt.Id);

            builder.HasOne(rt => rt.Tour)
                .WithMany(t => t.ReservationTour)
                .HasForeignKey(rt => rt.TourId);

            builder.HasOne(rt => rt.User)
                .WithMany(u => u.ReservationTours)
                .HasForeignKey(rt => rt.UserId);
        }
    }
}
