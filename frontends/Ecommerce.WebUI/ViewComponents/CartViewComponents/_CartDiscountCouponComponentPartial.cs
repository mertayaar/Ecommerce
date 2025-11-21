using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.ViewComponents.ShoppingCartViewComponents
{
    public class _CartDiscountCouponComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
