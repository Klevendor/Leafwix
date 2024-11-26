using LeafwixServerDAL.Entities.Identity;

namespace LeafwixServerDAL.Entities.App
{
    public class NotificationSettings
    {
        public Guid Id { get; set; }
        public string Frequency { get; set; } // частота надисилань сповіщень(раз в n днів)
        public string Type { get; set; } // тип сповіщень із звуком, без звуку, вібрація...
        public TimeSpan PreferredNotificationTime { get; set; } // Час, коли користувач бажає отримувати сповіщення


        public Guid UserId { get; set; } // Зовнішній ключ для користувача
        public User User { get; set; }  // Навігаційна властивість до користувача
    }
}
