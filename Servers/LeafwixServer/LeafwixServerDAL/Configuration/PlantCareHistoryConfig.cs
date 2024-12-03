using LeafwixServerDAL.Entities.App;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeafwixServerDAL.Configuration
{
    public class PlantCareHistoryConfig : IEntityTypeConfiguration<Plant>
    {
        public void Configure(EntityTypeBuilder<Plant> builder)
        {
            builder.HasKey(sc => sc.Id);

        }
    }
}
