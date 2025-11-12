using Ecommerce.DtoLayer.CatalogDtos.SponsorBrandDtos;
using Ecommerce.WebUI.Services.CatalogServices.SponsorBrandServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.ViewComponents.DefaultViewComponents
{
    public class _VendorDefaultComponentPartial : ViewComponent
    {
        private readonly ISponsorBrandService _sponsorBrandService;

        public _VendorDefaultComponentPartial(ISponsorBrandService sponsorBrandService)
        {
            _sponsorBrandService = sponsorBrandService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _sponsorBrandService.GetAllSponsorBrandAsync();
            return View(values);
        }
    }
}
