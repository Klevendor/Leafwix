using LeafwixServerDAL.Entities.App;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeafwixServerDAL.Configuration
{
    public class PlantSpeciesConfig : IEntityTypeConfiguration<PlantSpecies>
    {
        public void Configure(EntityTypeBuilder<PlantSpecies> builder)
        {
            builder.HasKey(sc => sc.Id);

            builder.HasMany(ps => ps.PlantDiseases)
            .WithOne(pd => pd.PlantSpecies)
            .HasForeignKey(pd => pd.PlantSpeciesId);

            builder.HasMany(ps => ps.Plants)
            .WithOne(pd => pd.PlantSpecies)
            .HasForeignKey(pd => pd.PlantSpeciesId);

            builder.HasMany(ps => ps.PlantImages)
           .WithOne(pd => pd.PlantSpecies)
           .HasForeignKey(pd => pd.PlantSpeciesId);
        }
    }
}
