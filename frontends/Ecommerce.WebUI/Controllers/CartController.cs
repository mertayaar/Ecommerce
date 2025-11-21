using Ecommerce.DtoLayer.CartDtos;
using Ecommerce.WebUI.Services.CartServices;
using Ecommerce.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce.WebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;

        public CartController(IProductService productService, ICartService cartService)
        {
            _productService = productService;
            _cartService = cartService;
        }

        public async Task<IActionResult> Index(string code,string rate)
        {
            @ViewBag.code = code;

            decimal discountRate = 0;
            if (!string.IsNullOrEmpty(rate))
                decimal.TryParse(rate, out discountRate);

            @ViewBag.discountRate = discountRate;

            @ViewBag.directory1 = "Home Page";
            @ViewBag.directory2 = "Product List";
            @ViewBag.directory3 = "My Cart";

            var cart = await _cartService.GetCart();

            ViewBag.CartTotal = cart.TotalPrice;

            var tax = cart.TotalPrice / 100 * 10;
            var totalPriceWithTax = cart.TotalPrice + tax;

            var discountAmount = discountRate > 0 ? (totalPriceWithTax * discountRate) / 100 : 0;
            var totalAfterDiscount = totalPriceWithTax - discountAmount;

            ViewBag.Tax = tax;
            ViewBag.DiscountAmount = discountAmount;
            ViewBag.TotalWithTax = totalAfterDiscount;
            ViewBag.TotalPriceWithTaxBeforeDiscount = totalPriceWithTax;

            return View(cart);
        }

        public async Task<IActionResult> AddToCart(string id)
        {
            var values = await _productService.GetByIdProductAsync(id);
            var items = new CartItemDto
            {
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                Quantity = 1,
                ProductImageUrl = values.ProductImageUrl,
                Price = values.ProductPrice
            };
            await _cartService.AddToCart(items);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> RemoveFromCart(string id)
        {
            await _cartService.RemoveItemFromCart(id);
            return RedirectToAction("Index");
        }
    }
}
