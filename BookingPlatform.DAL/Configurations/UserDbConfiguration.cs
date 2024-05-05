using BookingPlatform.Core.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingPlatform.DAL.Configurations
{
    public class UserDbConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //builder.HasKey(u => u.Id);

            builder.HasMany(u => u.Reviews)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);

            builder.HasMany(u => u.ReservationTours)
                .WithOne(rt => rt.User)
                .HasForeignKey(rt => rt.UserId);
        }
    }
}
