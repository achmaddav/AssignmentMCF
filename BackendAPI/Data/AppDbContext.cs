using BackendAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TrBpkb> TrBpkbs { get; set; }
        public DbSet<MsStorageLocation> MsStorageLocations { get; set; }
        public DbSet<MsUser> MsUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrBpkb>()
                .HasOne(b => b.MsStorageLocation)
                .WithMany()
                .HasForeignKey(b => b.LocationId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
