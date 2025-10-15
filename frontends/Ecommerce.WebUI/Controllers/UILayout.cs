using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Controllers
{
    public class UILayout : Controller
    {
        public IActionResult _UILayout()
        {
            return View();
        }
    }
}
