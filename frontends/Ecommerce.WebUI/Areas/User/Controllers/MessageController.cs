using Ecommerce.WebUI.Services.Interfaces;
using Ecommerce.WebUI.Services.MessageServices;
using Ecommerce.WebUI.Services.OrderServices.OrderOrderingServices;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Areas.User.Controllers
{
    [Area("User")]

    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;

        public MessageController(IMessageService messageService, IUserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }

        public async Task<IActionResult> Inbox()
        {
            var user = await _userService.GetUserInfo();
            var values = await _messageService.GetInboxMessageAsync(user.Id);
            return View(values);
        }

        public async Task<IActionResult> Outbox()
        {
            var user = await _userService.GetUserInfo();
            var values = await _messageService.GetOutboxMessageAsync(user.Id);
            return View(values);
        }
    }
}
