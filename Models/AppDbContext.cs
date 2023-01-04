using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ISawItFirst.Models
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(c => new { c.LoginProvider, c.ProviderKey });
            _ = modelBuilder.Entity<IdentityUserRole<string>>().HasKey(c => new { c.UserId, c.RoleId });
            _ = modelBuilder.Entity<IdentityUserToken<string>>().HasKey(c => new { c.UserId, c.LoginProvider, c.Name });
        }
    }
}