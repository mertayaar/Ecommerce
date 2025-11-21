using Ecommerce.WebUI.Services.CartServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce.WebUI.ViewComponents.ShoppingCartViewComponents
{
    public class _CartProductListComponentPartial : ViewComponent
    {
        private readonly ICartService _cartService;

        public _CartProductListComponentPartial(ICartService cartService)
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
