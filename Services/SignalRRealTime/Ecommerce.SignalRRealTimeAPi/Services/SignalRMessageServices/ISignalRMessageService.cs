namespace Ecommerce.SignalRRealTimeAPi.Services.SignalRMessageServices
{
    public interface ISignalRMessageService
    {
        Task<int> GetTotalMessageCountByReceiverId(string id);

    }
}
