using Ecommerce.DtoLayer.ReviewDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Ecommerce.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index(string id)
        {
            @ViewBag.directory1 = "Home Page";
            @ViewBag.directory2 = "Products";
            @ViewBag.directory3 = "Product List";
            ViewBag.i = id;
            return View();
        }

        public IActionResult ProductDetail(string id)
        {
            @ViewBag.directory1 = "Home Page";
            @ViewBag.directory2 = "Products";
            @ViewBag.directory3 = "Product List";
            ViewBag.x = id;
            return View();
        }

        [HttpGet]
        public IActionResult AddComment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CreateReviewDto createReviewDto)
        {
            createReviewDto.ImageUrl = "test";
            createReviewDto.Rating = 5;
            createReviewDto.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            createReviewDto.Status = false;
            createReviewDto.ProductId = "68f41aa07438fb5ca208b42d";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createReviewDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7252/api/Reviews", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }

    }
}
