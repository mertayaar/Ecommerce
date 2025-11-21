using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Areas.User.ViewComponents._UserLayoutViewComponents
{
    public class _UserLayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
