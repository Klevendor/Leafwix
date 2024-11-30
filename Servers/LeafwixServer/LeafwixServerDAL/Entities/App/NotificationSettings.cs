using LeafwixServerDAL.Entities.Identity;

namespace LeafwixServerDAL.Entities.App
{
    public class NotificationSettings
    {
        public Guid Id { get; set; }
        public TimeSpan PreferredNotificationTime { get; set; } // Час сповіщення
        public bool EnableNotifications { get; set; } // Увімкнення сповіщень
        public string TimeZone { get; set; } = "UTC"; // Часовий пояс у форматі IANA (наприклад, "Europe/Kyiv")


        public Guid UserId { get; set; } // Зовнішній ключ для користувача
        public User User { get; set; } = null!;  // Навігаційна властивість до користувача
    }
}
