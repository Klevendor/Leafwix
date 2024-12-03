using LeafwixServerDAL.Entities.App;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeafwixServerDAL.Configuration
{
    public class PlantConfig : IEntityTypeConfiguration<Plant>
    {
        public void Configure(EntityTypeBuilder<Plant> builder)
        {
            builder.HasKey(sc => sc.Id);

            builder.HasMany(ps => ps.PlantCareHistories)
           .WithOne(pd => pd.Plant)
           .HasForeignKey(pd => pd.PlantId);
        }
    }
}
