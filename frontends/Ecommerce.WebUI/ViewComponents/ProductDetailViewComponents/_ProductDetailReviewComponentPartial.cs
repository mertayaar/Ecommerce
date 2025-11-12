using Ecommerce.DtoLayer.ReviewDtos;
using Ecommerce.WebUI.Services.ReviewServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ecommerce.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailReviewComponentPartial : ViewComponent
    {
       private readonly IReviewService _reviewService;

        public _ProductDetailReviewComponentPartial(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _reviewService.ReviewListByProductId(id);
            return View(values);
        }
    }
}
