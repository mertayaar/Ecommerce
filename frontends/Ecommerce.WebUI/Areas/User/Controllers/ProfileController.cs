using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Areas.User.Controllers
{
    public class ProfileController : Controller
    {
        [Area("User")]

        public IActionResult Index()
        {
            return View();
        }
    }
}
