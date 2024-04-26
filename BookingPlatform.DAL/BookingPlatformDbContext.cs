using BookingPlatform.Core.Identity;
using BookingPlatform.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingPlatform.DAL
{
    public class BookingPlatformDbContext(DbContextOptions<BookingPlatformDbContext> options) 
        : DbContext(options)
    {
        public DbSet<Tour> Tours { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookingPlatformDbContext).Assembly);
        }
    }
}
