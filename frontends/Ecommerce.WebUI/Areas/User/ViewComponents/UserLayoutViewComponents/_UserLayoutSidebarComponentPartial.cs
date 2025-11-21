using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Areas.User.ViewComponents.UserLayoutViewComponents
{
    public class _UserLayoutSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
