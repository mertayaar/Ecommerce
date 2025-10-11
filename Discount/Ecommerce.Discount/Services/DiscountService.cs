using Dapper;
using Ecommerce.Discount.Context;
using Ecommerce.Discount.Dtos;

namespace Ecommerce.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;

        public DiscountService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateCouponAsync(CreateDiscountCouponDto createCouponDto)
        {
            string query = "insert into Coupons (CouponCode,CouponRate,IsActive,ValidDate) values (@couponCode,@couponRate,@isActive,@validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@couponCode", createCouponDto.CouponCode);
            parameters.Add("@couponRate", createCouponDto.CouponRate);
            parameters.Add("@isActive", createCouponDto.IsActive);
            parameters.Add("@validDate", createCouponDto.ValidDate);
            using(var connection= _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCouponAsync(int id)
        {
            string query = "delete fron Coupons where CouponID=@couponID";
            var parameters = new DynamicParameters();
            parameters.Add("@couponID", id);
            using(var connection= _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllCouponAsync()
        {
            string query = "select * from Coupons";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultDiscountCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDDiscountCouponDto> GetByIDCouponAsync(int id)
        {
            string query = "select * from Coupons where CouponID=@couponID";
            var parameters = new DynamicParameters();
            parameters.Add("@couponID", id);
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIDDiscountCouponDto>(query);
                return values;
            }
        }

        public async Task UpdateCouponAsync(UpdateDiscountCouponDto updateCouponDto)
        {
            string query = "Update Coupons Set CouponCode=@couponCode,CouponRate=@couponRate,IsActive=@isActive,ValidDate=@validDate where CouponID=@couponID";
            var parameters = new DynamicParameters();
            parameters.Add("@couponCode", updateCouponDto.CouponCode);
            parameters.Add("@couponRate", updateCouponDto.CouponRate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            parameters.Add("@validDate", updateCouponDto.ValidDate);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
