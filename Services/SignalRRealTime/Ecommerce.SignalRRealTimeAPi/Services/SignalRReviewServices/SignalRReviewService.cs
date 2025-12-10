
using Ecommerce.Common;

namespace Ecommerce.SignalRRealTimeAPi.Services.SignalRReviewServices
{
    public class SignalRReviewService : ISignalRReviewService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SignalRReviewService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<int> ReviewCount()
        {
            var client = _httpClientFactory.CreateClient();
            //var responseMessage = await _httpClient.GetAsync("reviews/TotalReviewCount");
            var responseMessage = await client.GetAsync("http://localhost:7225/api/ReviewStatistics");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
