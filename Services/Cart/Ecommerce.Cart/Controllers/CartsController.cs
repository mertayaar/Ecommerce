using Ecommerce.Cart.Dtos;
using Ecommerce.Cart.LoginServices;
using Ecommerce.Cart.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Cart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly ILoginService _loginService;

        public CartsController(ICartService cartService, ILoginService loginService)
        {
            _cartService = cartService;
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyCartDetail()
        {
            var values = await _cartService.GetCart(_loginService.GetUserId);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> SaveMyCart(CartTotalDto cartTotalDto)
        {
            cartTotalDto.UserId = _loginService.GetUserId;
            await _cartService.SaveCart(cartTotalDto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCart()
        {
            await _cartService.DeleteCart(_loginService.GetUserId);
            return Ok();
        }


    }
}
