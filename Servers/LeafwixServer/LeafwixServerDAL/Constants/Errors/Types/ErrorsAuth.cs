using LeafwixServerDAL.Constants.Errors.Base;

namespace LeafwixServerDAL.Constants.Errors.Types
{
    public static partial class Errors
    {
        public static class Authorization
        {
            public static Error UsernameExists => new Error(
             code: "Auth.UserNameExists",
             description: "Username already exists"
            );

            public static Error RegistrationFailed => new Error(
                code: "Auth.RegistratinFailed", 
                description: "User registration failed"
            );

            public static Error InvalidEmailOrPassword => new Error(
                code: "Auth.InvalidEmailOrPassword",
                description: "Invalid email or password"
            );

            public static Error BannedUser => new Error(
                code: "Auth.UserBanned",
                description: "Account was banned"
            );

            public static Error TokenNotFound => new Error(
                code: "Auth.TokenNotFound",
                description: "Refresh token not found"
            );

            public static Error UserNotFound => new Error(
                code: "Auth.UserNotFound",  
                description: "User not found"
            );

            public static Error InvalidEmail => new Error(
                code: "Auth.InvalidEmail", 
                description: "Invalid email"
            );

            public static Error InvalidToken => new Error(
                code: "Auth.InvalidToken",
                description: "Invalid token"
            );

            public static Error InvalidTokenOrPassword => new Error(
                code: "Auth.InvalidTokenOrPassword",
                description: "Invalid token or password"
            );
        }
    }
}
