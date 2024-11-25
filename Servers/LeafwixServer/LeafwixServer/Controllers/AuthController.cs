using LeafwixServer.Authorization.CustomAttributes;
using LeafwixServerBLL.Models;
using LeafwixServerBLL.Services.Interfaces;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace LeafwixServer.Controllers
{
    [Route("api/auth")]
    public class AuthController : ApiController
    {
        private readonly IMapper _mapper;

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var userRegisterInformation = _mapper.Map<UserRegisterInformation>(request);

            var result = await _authService.RegisterAsync(userRegisterInformation);

            return result.Match(
                result => Ok(result),
                problems => Problem(problems)
                );
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var userLoginInformation = _mapper.Map<UserLoginInformation>(request);

           var result = await _authService.LoginAsync(userLoginInformation);

            return result.Match(
                result =>
                {
                    SetTokenCookie(result.RefreshToken);
                    return Ok(result);
                },
                problems => Problem(problems)
                );
        }

        [Authorize("User,Administrator,Moderator")]
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            ClearTokenCookie();
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("refresh-tokens")]
        public async Task<IActionResult> RefreshTokens()
        {
            var refreshToken = Request.Cookies["refreshToken"] ?? "";

            var result = await _authService.RefreshTokensAsync(refreshToken, IpAddress());

            return result.Match(
                result =>
                {
                    SetTokenCookie(result.RefreshToken);
                    return Ok(result);
                },
                problems => Problem(problems)
                );
        }

        [AllowAnonymous]
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest request)
        {
            var forgotPasswordInformation = _mapper.Map<ForgotPasswordInformation>(request);
            var result = await _authService.ForgotPasswordAsync(forgotPasswordInformation);
            return result.Match(
               result => Ok(),
               problems => Problem(problems)
               );
        }

        [AllowAnonymous]
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            var resetPasswordInformation = _mapper.Map<ResetPasswordInformation>(request);
            var result = await _authService.ResetPasswordAsync(resetPasswordInformation);

            return result.Match(
              result => Ok(),
              problems => Problem(problems)
              );
        }

        /* 

         Methods for help

        */

        private void SetTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7),
                SameSite = SameSiteMode.None,
                Secure = true
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }

        private void ClearTokenCookie()
        {
            var cookiesToClear = new string[] {
                "refreshToken"
            };

            foreach (var cookie in cookiesToClear)
            {
                if (Request.Cookies.ContainsKey(cookie))
                {
                    Response.Cookies.Delete(cookie);
                }
            }

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(-1d),
                SameSite = SameSiteMode.None,
                Secure = true
            };
            Response.Cookies.Append("refreshToken", "", cookieOptions);
        }

        private string IpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}