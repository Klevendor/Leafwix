using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LeafwixServerDAL.Entities.Identity;
using LeafwixServerDAL.Entities.App;
using LeafwixServerDAL.Configuration;
using LeafwixServerDAL.Context.Interfaces;
using LeafwixServerDAL.Entities.Security;

namespace LeafwixServerDAL.Context.Implementation
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>, IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) {
        
        }

        public DbSet<NotificationSettings> NotificationSettings { get; set; }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<PlantSpecies> PlantSpecies { get; set; }
        public DbSet<PlantDiseases> PlantDiseases { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Add configs

            //modelBuilder.ApplyConfiguration();
            modelBuilder.ApplyConfiguration(new NotificationSettingsConfig());
            modelBuilder.ApplyConfiguration(new PlantConfig());
            modelBuilder.ApplyConfiguration(new PlantSpeciesConfig());
            modelBuilder.ApplyConfiguration(new PlantDiseasesConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
