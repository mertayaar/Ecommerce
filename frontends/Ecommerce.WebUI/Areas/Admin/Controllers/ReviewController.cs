using Ecommerce.DtoLayer.ReviewDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Ecommerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Review")]
    public class ReviewController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReviewController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "Review Operation";
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "Reviews";
            ViewBag.v3 = "Review List";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7252/api/Reviews");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultReviewDto>>(jsonData);
                return View(values);
            }
            return View();
        }



        [Route("DeleteReview/{id}")]

        public async Task<IActionResult> DeleteReview(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7252/api/Reviews?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Review", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateReview/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateReview(string id)
        {
            ViewBag.v0 = "Home Page";
            ViewBag.v1 = "Reviews";
            ViewBag.v2 = "Update Review";
            ViewBag.v3 = "Review Operations";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7252/api/Reviews/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateReviewDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("UpdateReview/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateReview(UpdateReviewDto updateReviewDto)
        {
            updateReviewDto.Status = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateReviewDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7252/api/Reviews/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Review", new { area = "Admin" });
            }
            return View();
        }

    }
}
