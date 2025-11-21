using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.ViewComponents.OrderViewComponents
{
    public class _OrderPaymentMethodComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
