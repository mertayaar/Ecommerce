using Ecommerce.WebUI.Services.CartServices;
using Ecommerce.WebUI.Services.DiscountServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly ICartService _cartService;

        public DiscountController(IDiscountService discountService, ICartService cartService)
        {
            _discountService = discountService;
            _cartService = cartService;
        }

        [HttpGet]
        public PartialViewResult ConfirmDiscountCoupon()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmDiscountCoupon(string code)
        {
            var values = await _discountService.GetDiscountCode(code);        
            return RedirectToAction("Index", "Cart", new { code = code, rate = values.CouponRate });
        }
    }
}
