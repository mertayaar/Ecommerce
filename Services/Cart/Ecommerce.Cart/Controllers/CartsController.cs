using Ecommerce.Cart.Dtos;
using Ecommerce.Cart.LoginServices;
using Ecommerce.Cart.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Common;

namespace Ecommerce.Cart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
            if (values == null)
                return NoContent();

            return Ok(ApiResponse<object>.Ok(values));
        }

        [HttpPost]
        public async Task<IActionResult> SaveCart(CartTotalDto cartTotalDto)
        {
            if (!ModelState.IsValid)
            {
                var modelErrors = string.Join("; ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return BadRequest(ApiResponse.Fail(modelErrors));
            }

            cartTotalDto.UserId = _loginService.GetUserId;
            await _cartService.SaveCart(cartTotalDto);
            return StatusCode(StatusCodes.Status201Created, ApiResponse.Ok(ApiMessages.Created));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCart()
        {
            await _cartService.DeleteCart(_loginService.GetUserId);
            return NoContent();
        }


    }
}

