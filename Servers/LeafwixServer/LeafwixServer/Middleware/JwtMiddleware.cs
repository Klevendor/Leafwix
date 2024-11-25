using LeafwixServerBLL.Services.Interfaces;

namespace LeafwixServer.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IAuthService authService, IJwtService jwtService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                var userId = jwtService.ValidateJwtToken(token);

                if (userId != Guid.Empty)
                {
                    var user = await authService.GetUserByIdAsync(userId);
                    var userRoles = await authService.GetUserRolesAsync(user);
                    context.Items["User"] = user;
                    context.Items["Roles"] = userRoles;
                }
            }

            await _next(context);
        }
    }
}
