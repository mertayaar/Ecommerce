using Ecommerce.DtoLayer.MessageDtos;

namespace Ecommerce.WebUI.Services.MessageServices
{
    public interface IMessageService
    {
        //Task<List<ResultMessageDto>> GetAllMessageAsync();
        Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id);
        Task<List<ResultOutboxMessageDto>> GetOutboxMessageAsync(string id);
        //Task CreateMessageAsync(CreateMessageDto createMessageDto);
        //Task UpdateMessageAsync(UpdateMessageDto updateMessageDto);
        //Task DeleteMessageAsync(int id);
        //Task<GetByIdMessageDto> GetByIdMessageAsync(int id);
    }
}
