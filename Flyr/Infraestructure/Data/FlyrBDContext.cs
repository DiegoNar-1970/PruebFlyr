using Flyr.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flyr.Infrastructure.Data
{
    public class FlyrDbContext : DbContext
    {
        public FlyrDbContext(DbContextOptions<FlyrDbContext> options) : base(options) { }

        public DbSet<Journey> Journeys => Set<Journey>();
        public DbSet<Flight> Flights => Set<Flight>();
        public DbSet<Transport> Transports => Set<Transport>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Journey>()
                .HasMany(j => j.Flights)
                .WithOne()
                .HasForeignKey("JourneyId")
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Flight>()
                .HasOne(f => f.Transport)
                .WithMany()
                .HasForeignKey(f => f.TransportId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
}
    }
}
