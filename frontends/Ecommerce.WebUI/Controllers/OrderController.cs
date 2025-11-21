using Ecommerce.DtoLayer.OrderDtos.OrderAddressDtos;
using Ecommerce.WebUI.Services.Interfaces;
using Ecommerce.WebUI.Services.OrderServices.OrderAddressServices;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderAddressService _orderAddressService;
        private readonly IUserService _userService;


        public OrderController(IOrderAddressService orderAddressService, IUserService userService)
        {
            _orderAddressService = orderAddressService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            @ViewBag.directory1 = "Home Page";
            @ViewBag.directory2 = "Orders";
            @ViewBag.directory3 = "Checkout";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateOrderAddressDto createOrderAddressDto)
        {
            var values = await _userService.GetUserInfo();
            createOrderAddressDto.UserId = values.Id;
            await _orderAddressService.CreateOrderAddressAsync(createOrderAddressDto);
            return RedirectToAction("Index", "Payment");
        }
    }
}
