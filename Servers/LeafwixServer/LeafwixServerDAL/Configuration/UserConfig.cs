using LeafwixServerDAL.Entities.App;
using LeafwixServerDAL.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeafwixServerDAL.Configuration
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(sc => sc.Id);

            builder.HasMany(ps => ps.Plants)
            .WithOne(pd => pd.User)
            .HasForeignKey(pd => pd.UserId);

            builder.HasOne(u => u.NotificationSettings)
            .WithOne(ns => ns.User)
            .HasForeignKey<NotificationSettings>(ns => ns.UserId);

        }
    }
}
