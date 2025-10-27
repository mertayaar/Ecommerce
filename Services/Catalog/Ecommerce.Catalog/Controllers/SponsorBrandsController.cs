using Ecommerce.Catalog.Dtos.SponsorBrandDtos;
using Ecommerce.Catalog.Services.SponsorBrandServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class SponsorBrandsController : ControllerBase
    {
        private readonly ISponsorBrandService _sponsorBrandService;

        public SponsorBrandsController(ISponsorBrandService sponsorBrandService)
        {
            _sponsorBrandService = sponsorBrandService;
        }

        [HttpGet]
        public async Task<IActionResult> SponsorBrandList()
        {
            var values = await _sponsorBrandService.GetAllSponsorBrandAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSponsorBrandById(string id)
        {
            var value = await _sponsorBrandService.GetByIdSponsorBrandAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSponsorBrand(CreateSponsorBrandDto createSponsorBrandDto)
        {
            await _sponsorBrandService.CreateSponsorBrandAsync(createSponsorBrandDto);
            return Ok(createSponsorBrandDto);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSponsorBrand(string id)
        {
            await _sponsorBrandService.DeleteSponsorBrandAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSponsorBrand(UpdateSponsorBrandDto updateSponsorBrandDto)
        {
            await _sponsorBrandService.UpdateSponsorBrandAsync(updateSponsorBrandDto);
            return Ok();
        }
    }
}
