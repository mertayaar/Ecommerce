using Ecommerce.WebUI.Services.Interfaces;
using Ecommerce.WebUI.Services.OrderServices.OrderOrderingServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class OrderHistoryController : Controller
    {
        private readonly IOrderOrderingService _orderOrderingService;
        private readonly IUserService _userService;

        public OrderHistoryController(IOrderOrderingService orderOrderingService, IUserService userService)
        {
            _orderOrderingService = orderOrderingService;
            _userService = userService;
        }

        public async Task<IActionResult> OrderHistoryList()
        {
            var user= await _userService.GetUserInfo();
            var values = await _orderOrderingService.GetOrderingByUserIdAsync(user.Id);
            return View(values);
        }
    }
}
