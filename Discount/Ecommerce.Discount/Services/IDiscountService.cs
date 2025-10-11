using Ecommerce.Discount.Dtos;

namespace Ecommerce.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultDiscountCouponDto>> GetAllCouponAsync();
        Task CreateCouponAsync(CreateDiscountCouponDto createCouponDto);
        Task UpdateCouponAsync(UpdateDiscountCouponDto updateCouponDto);
        Task DeleteCouponAsync(int id);
        Task<GetByIDDiscountCouponDto> GetByIDCouponAsync(int id);
    }
}
