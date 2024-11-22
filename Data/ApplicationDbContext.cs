using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PROG6212CMCSAPP.Models;

namespace PROG6212CMCSAPP.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Claim> Claims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Claims
            modelBuilder.Entity<Claim>(entity =>
            {
                entity.Property(c => c.HourlyRate)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                // Ignore TotalAmount since it is calculated in C# and should not be mapped to the database
                entity.Ignore(c => c.TotalAmount);

                entity.Property(c => c.Status)
                    .HasMaxLength(20)
                    .IsRequired();

                entity.Property(c => c.DocumentType)
                    .HasMaxLength(100);

                // Configure relationship with ApplicationUser
                entity.HasOne(c => c.Lecturer)
                    .WithMany(u => u.Claims)
                    .HasForeignKey("LecturerId")
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Add indexes
            modelBuilder.Entity<Claim>()
                .HasIndex(c => c.Status);

            modelBuilder.Entity<Claim>()
                .HasIndex(c => c.SubmissionDate);
        }
    }
}
