using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Controllers
{
    public class ShoppingCart : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
