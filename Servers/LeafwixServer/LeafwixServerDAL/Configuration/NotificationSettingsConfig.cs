using LeafwixServerDAL.Entities.App;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeafwixServerDAL.Configuration
{
    public class NotificationSettingsConfig : IEntityTypeConfiguration<NotificationSettings>
    {
        public void Configure(EntityTypeBuilder<NotificationSettings> builder)
        {
            builder.HasKey(sc => sc.Id);
        }


    }
}
