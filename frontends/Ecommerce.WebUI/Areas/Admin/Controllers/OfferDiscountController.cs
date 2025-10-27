using Ecommerce.DtoLayer.CatalogDtos.OfferDiscountDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Ecommerce.WebUI.Areas.Admin.Controllers
{
 
        [Area("Admin")]
        [AllowAnonymous]
        [Route("Admin/OfferDiscount")]
        public class OfferDiscountController : Controller
        {
            private readonly IHttpClientFactory _httpClientFactory;

            public OfferDiscountController(IHttpClientFactory httpClientFactory)
            {
                _httpClientFactory = httpClientFactory;
            }

            [Route("Index")]
            public async Task<IActionResult> Index()
            {
                ViewBag.v0 = "OfferDiscount Operation";
                ViewBag.v1 = "Home Page";
                ViewBag.v2 = "OfferDiscounts";
                ViewBag.v3 = "OfferDiscount List";

                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("https://localhost:7220/api/OfferDiscounts");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultOfferDiscountDto>>(jsonData);
                    return View(values);
                }
                return View();
            }


            [HttpGet]
            [Route("CreateOfferDiscount")]

            public IActionResult CreateOfferDiscount()
            {
                ViewBag.v0 = "Home Page";
                ViewBag.v1 = "OfferDiscounts";
                ViewBag.v2 = "Add New OfferDiscount";
                ViewBag.v3 = "OfferDiscount Operations";
                return View();
            }

            [HttpPost]
            [Route("CreateOfferDiscount")]

            public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createOfferDiscountDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7220/api/OfferDiscounts", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
                }
                return View();
            }

            [Route("DeleteOfferDiscount/{id}")]

            public async Task<IActionResult> DeleteOfferDiscount(string id)
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.DeleteAsync("https://localhost:7220/api/OfferDiscounts?id=" + id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
                }
                return View();
            }

            [Route("UpdateOfferDiscount/{id}")]
            [HttpGet]
            public async Task<IActionResult> UpdateOfferDiscount(string id)
            {
                ViewBag.v0 = "Home Page";
                ViewBag.v1 = "OfferDiscounts";
                ViewBag.v2 = "Update OfferDiscount";
                ViewBag.v3 = "OfferDiscount Operations";
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync("https://localhost:7220/api/OfferDiscounts/" + id);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<UpdateOfferDiscountDto>(jsonData);
                    return View(values);
                }
                return View();
            }

            [Route("UpdateOfferDiscount/{id}")]
            [HttpPost]
            public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
            {

                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(updateOfferDiscountDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("https://localhost:7220/api/OfferDiscounts/", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
                }
                return View();
            }

        }
    }
