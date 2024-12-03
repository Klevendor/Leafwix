using LeafwixServerBLL.Services.Interfaces;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using LeafwixServer.Authorization.CustomAttributes;
using OneOf.Types;
using LeafwixServerBLL.Models;

namespace LeafwixServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationSettingsController : ApiController
    {
        private readonly INotificationSettingsService _notifSettingsService;

        public NotificationSettingsController(INotificationSettingsService notifSettingsService)
        {
            _notifSettingsService = notifSettingsService;
        }

        //[Authorize("User,Administrator,Moderator")]
        [HttpGet("notification")]
        public async Task<IActionResult> GetUserNotificationSettings(Guid userId)
        {
            var result = await _notifSettingsService.GetByUserIdAsync(userId);
            return result.Match(
                result => Ok(result),
                problems => Problem(problems)
                );
        }

        //[Authorize("User,Administrator,Moderator")]
        [HttpPost("update-notification")]
        public async Task<IActionResult> UpdateNotificationSettings(NotificationSettingsRequest obj)
        {
            var result = await _notifSettingsService.UpdateAsync(obj);
            return result.Match(
                result => Ok(result),
                problems => Problem(problems)
                );
        }
    }
}
