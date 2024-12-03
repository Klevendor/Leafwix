using LeafwixServerDAL.Constants.Errors.Base;

namespace LeafwixServerDAL.Constants.Errors.Types
{

    public static partial class Errors
    {
        public static class NotificationSettings
        {
            public static Error NotificationSettingsNotFound => new Error(
                code: "NotificationSettings.NotificationSettingsNotFound",
                description: "NotificationSettings not found"
            );
        }
    }
}
