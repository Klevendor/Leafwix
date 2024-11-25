using LeafwixServerDAL.Entities.Identity;
using System.Text.Json.Serialization;

namespace LeafwixServerDAL.Entities.Security
{
    public class RefreshToken
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        public string Token { get; set; }

        public DateTime Expires { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Revoked { get; set; }

        public bool IsExpired => DateTime.UtcNow >= Expires;

        public bool IsActive => Revoked == null && !IsExpired;

        public Guid OwnerId { get; set; }

        public User Owner { get; set; }
    }
}
