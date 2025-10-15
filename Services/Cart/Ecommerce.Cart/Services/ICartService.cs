using Ecommerce.Cart.Dtos;

namespace Ecommerce.Cart.Services
{
    public interface ICartService
    {
        Task<CartTotalDto> GetCart(string userId);
        Task SaveCart(CartTotalDto cart);
        Task DeleteCart(string userId);
    }
}
