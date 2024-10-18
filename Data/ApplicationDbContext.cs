using Microsoft.EntityFrameworkCore;
using PROG6212CMCSAPP.Models;

namespace PROG6212CMCSAPP.Data
{
    //database
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Claim> Claims { get; set; }//Database creation

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Claim>()
                .Property(c => c.HourlyRate)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Claim>()
                .Property(c => c.TotalAmount)
                .HasColumnType("decimal(18,2)");

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Claim>().ToTable("Claims");
        }
    }
}
