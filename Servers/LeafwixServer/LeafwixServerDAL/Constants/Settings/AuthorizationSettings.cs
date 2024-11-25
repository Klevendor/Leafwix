using LeafwixServerDAL.Enums;

namespace LeafwixServerDAL.Constants.Settings
{
    public static class AuthorizationSettings
    {
        public const string DefaultUsername = "SuperUser";
        public const string DefaultPassword = "password";
        public const string DefaultEmail = "superuser@test.com";
        public const AppRoles SuperUserRole = AppRoles.Administrator;
    }
}
