using HTMLPreviewerApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HTMLPreviewerApp.Data
{
    public class PreviewerDbContext : IdentityDbContext<User>
    {
        public PreviewerDbContext(DbContextOptions<PreviewerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Sample> Samples { get; init; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Sample>()
                .HasOne(s => s.User)
                .WithMany(u => u.Samples)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
