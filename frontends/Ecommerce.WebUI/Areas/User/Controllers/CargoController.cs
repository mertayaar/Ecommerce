using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Areas.User.Controllers
{
    public class CargoController : Controller
    {
        [Area("User")]

        public IActionResult MyOrderHistoryList()
        {
            return View();
        }
    }
}
