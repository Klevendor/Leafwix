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
    public class PlantImageConfig : IEntityTypeConfiguration<PlantImage>
    {
        public void Configure(EntityTypeBuilder<PlantImage> builder)
        {
            builder.HasKey(sc => sc.Id);


        }
    }
}
