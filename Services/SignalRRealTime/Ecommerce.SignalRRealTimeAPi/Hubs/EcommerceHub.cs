using Ecommerce.SignalRRealTimeAPi.Services.SignalRMessageServices;
using Ecommerce.SignalRRealTimeAPi.Services.SignalRReviewServices;
using Microsoft.AspNetCore.SignalR;

namespace Ecommerce.SignalRRealTimeAPi.Hubs
{
    public class EcommerceHub : Hub
    {
        private readonly ISignalRReviewService _signalRReviewService;

        public EcommerceHub(ISignalRReviewService signalRReviewService)
        {
           _signalRReviewService = signalRReviewService;
        }

        public async Task SendStatisticCount()
        {
            var reviewCount = await _signalRReviewService.ReviewCount();
            await Clients.All.SendAsync("ReceiveReviewCount", reviewCount);

        }
    }
}
