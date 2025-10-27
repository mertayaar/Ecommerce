using Ecommerce.DtoLayer.CatalogDtos.SponsorBrandDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Ecommerce.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/SponsorBrand")]
    public class SponsorBrandController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SponsorBrandController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v0 = "SponsorBrand Operation";
            ViewBag.v1 = "Home Page";
            ViewBag.v2 = "SponsorBrands";
            ViewBag.v3 = "SponsorBrand List";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7220/api/SponsorBrands");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSponsorBrandDto>>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpGet]
        [Route("CreateSponsorBrand")]

        public IActionResult CreateSponsorBrand()
        {
            ViewBag.v0 = "Home Page";
            ViewBag.v1 = "SponsorBrands";
            ViewBag.v2 = "Add New SponsorBrand";
            ViewBag.v3 = "SponsorBrand Operations";
            return View();
        }

        [HttpPost]
        [Route("CreateSponsorBrand")]

        public async Task<IActionResult> CreateSponsorBrand(CreateSponsorBrandDto createSponsorBrandDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSponsorBrandDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7220/api/SponsorBrands", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SponsorBrand", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteSponsorBrand/{id}")]

        public async Task<IActionResult> DeleteSponsorBrand(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7220/api/SponsorBrands?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SponsorBrand", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateSponsorBrand/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateSponsorBrand(string id)
        {
            ViewBag.v0 = "Home Page";
            ViewBag.v1 = "SponsorBrands";
            ViewBag.v2 = "Update SponsorBrand";
            ViewBag.v3 = "SponsorBrand Operations";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7220/api/SponsorBrands/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateSponsorBrandDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("UpdateSponsorBrand/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateSponsorBrand(UpdateSponsorBrandDto updateSponsorBrandDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateSponsorBrandDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7220/api/SponsorBrands/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SponsorBrand", new { area = "Admin" });
            }
            return View();
        }

    }
}
