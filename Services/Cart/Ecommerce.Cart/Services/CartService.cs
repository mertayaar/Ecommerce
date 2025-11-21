using Ecommerce.Cart.Dtos;
using Ecommerce.Cart.Settings;
using System.Text.Json;

namespace Ecommerce.Cart.Services
{
    public class CartService : ICartService
    {
        private readonly RedisService _redisService;

        public CartService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task DeleteCart(string userId)
        {
            await _redisService.GetDb().KeyDeleteAsync(userId);

        }

        public async Task<CartTotalDto> GetCart(string userId)
        {
            var existCart =await _redisService.GetDb().StringGetAsync(userId);
            if (string.IsNullOrEmpty(existCart))
            {
                return new CartTotalDto
                {
                    CartItems = new List<CartItemDto>(),
                };
            }
            return JsonSerializer.Deserialize<CartTotalDto>(existCart);
            
        }

        public async Task SaveCart(CartTotalDto cartTotalDto)
        {
            await _redisService.GetDb().StringSetAsync(cartTotalDto.UserId, JsonSerializer.Serialize(cartTotalDto));
        }
    }
}
