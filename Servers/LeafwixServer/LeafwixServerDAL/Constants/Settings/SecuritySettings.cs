namespace LeafwixServerDAL.Constants.Settings
{
    public static class SecuritySettings
    {
        public static class Passwords
        {
            public static bool RequireDigit = false;
            public static bool RequireLowercase = false;
            public static bool RequireNonAlphanumeric = false;
            public static bool RequireUppercase = false;
            public static int RequiredLength = 6;
            public static int RequiredUniqueChars = 1;

            public static bool RequireUniqueEmail = true;
            public static bool RequireConfirmedEmail = false;

            public static string AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ2456456789_ ";

        }
    }
}
