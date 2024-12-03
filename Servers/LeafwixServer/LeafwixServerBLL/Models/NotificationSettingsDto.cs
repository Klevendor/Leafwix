namespace LeafwixServerBLL.Models
{
    /* Request Models  */
    public record NotificationSettingsRequest(
        Guid userId,
        TimeSpan PreferredNotificationTime,
        bool EnableNotifications,
        string TimeZone
    );

    /* Response Models */
    public record NotificationSettingsResponse(
        TimeSpan PreferredNotificationTime,
        bool EnableNotifications,
        string TimeZone
    );

}
