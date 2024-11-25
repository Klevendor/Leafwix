using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LeafwixServerDAL.Entities.Identity;
using LeafwixServerDAL.Context.Interfaces;
using LeafwixServerDAL.Entities.Security;

namespace LeafwixServerDAL.Context.Implementation
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>, IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Add configs

            //modelBuilder.ApplyConfiguration();



            base.OnModelCreating(modelBuilder);
        }
    }
}
