using System.Text.Json.Serialization;

namespace LeafwixServerBLL.Models
{
    /* Request Models  */

    public record RegisterRequest(
        string UserName,
        string Email,
        string Password
        );

    public record LoginRequest(
        string Email,
        string Password
        );

    public record ForgotPasswordRequest(
        string Email
        );

    public record ResetPasswordRequest(
        string Email,
        string NewPassword,
        string Token
        );

    public record RevokeRefreshTokenRequest(
      string Token
      );

    /* Service Models */

    public record UserRegisterInformation(
       string UserName,
       string Password,
       string Email
       );

    public record UserLoginInformation(
        string Email,
        string Password,
        string IpAddress
       );

    public record ForgotPasswordInformation(
        string Email
        );

    public record ResetPasswordInformation(
        string Email,
        string NewPassword,
        string Token
        );

    public record RevokeRefreshTokenInformation(
     string Token
     );

    /* Response Models */

    public record RefreshDataResponse(
       Guid Id,
       string Email,
       string UserName,
       IList<string> Roles,  //!!!! diff
       string Token,
       [property: JsonIgnore] string RefreshToken,
       [property: JsonIgnore] DateTime RefreshTokenExpiration
       );

    public class AuthenticationResponse
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public IList<string> UserRoles { get; set; }
        public string Token { get; set; }
        [JsonIgnore]
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
    }

}
