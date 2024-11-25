namespace LeafwixServerDAL.Constants.Settings
{
    public class JwtSettings
    {
        public string Secret { get; set; } = string.Empty;

        public string Issuer { get; set; } = string.Empty;

        public string Audience { get; set; } = string.Empty;

        public double DurationInMinutes { get; set; }

        public int RefreshTokenTTL { get; set; }

        public const string DefaultRoleForProject = "User";
    }
}
