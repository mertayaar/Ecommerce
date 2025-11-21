using Ecommerce.WebUI.Services.CartServices;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.ViewComponents.OrderViewComponents
{
    public class _OrderSummaryComponentPartial : ViewComponent
    {
        private readonly ICartService _cartService;

        public _OrderSummaryComponentPartial(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _cartService.GetCart();
            var items = values.CartItems;

            return View(items);
        }
    }
}
