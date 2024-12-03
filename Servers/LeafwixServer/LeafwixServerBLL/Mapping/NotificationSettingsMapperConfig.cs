using LeafwixServerBLL.Models;
using Mapster;

namespace LeafwixServerBLL.Mapping
{
    public class NotificationSettingsMapperConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<NotificationSettingsRequest, NotificationSettingsResponse>();
        }
    }
}
