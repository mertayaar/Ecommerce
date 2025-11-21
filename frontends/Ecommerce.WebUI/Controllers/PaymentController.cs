using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            @ViewBag.directory1 = "Home Page";
            @ViewBag.directory2 = "Payment";
            @ViewBag.directory3 = "Credit Card";
            return View();
        }
    }
}
