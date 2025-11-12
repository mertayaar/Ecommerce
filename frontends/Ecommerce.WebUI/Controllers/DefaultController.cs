using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            @ViewBag.directory1 = "Home Page";
            @ViewBag.directory2 = "Product List";
            return View();
        }
    }
}
