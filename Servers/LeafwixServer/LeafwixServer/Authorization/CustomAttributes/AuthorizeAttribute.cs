using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using LeafwixServerDAL.Entities.Identity;
using LeafwixServerDAL.Constants.Settings;

namespace LeafwixServer.Authorization.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly List<string> _roles = new List<string>();

        public AuthorizeAttribute()
        {
            _roles.Add(JwtSettings.DefaultRoleForProject);
        }

        public AuthorizeAttribute(string roles)
        {
            string[] required_roles = roles.Split(",");

            foreach (string role in required_roles)
            {
                _roles.Add(role);
            }
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            var user = context.HttpContext.Items["User"] as User;
            var userRoles = context.HttpContext.Items["Roles"] as List<string>;

            if (user == null)
            {
                context.Result = Problem("Unauthorized", StatusCodes.Status401Unauthorized);
            }
            else
            {
                bool userHasRole = userRoles?.Any(role => _roles.Contains(role)) ?? false;
                if (!userHasRole)
                    context.Result = Problem("Forbidden", StatusCodes.Status403Forbidden);
            }
        }

        private JsonResult Problem(string title, int statusCode)
        {
            var type = statusCode == 401
                ? "https://tools.ietf.org/html/rfc9110#section-15.5.2"
                : "https://tools.ietf.org/html/rfc9110#section-15.5.3";

            var result = new JsonResult(
                new
                {
                    type,
                    title,
                    status = statusCode,
                })
            {
                StatusCode = statusCode
            };

            return result;
        }
    }
}
