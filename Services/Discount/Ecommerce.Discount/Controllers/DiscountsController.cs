using Ecommerce.Discount.Dtos;
using Ecommerce.Discount.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Common;

namespace Ecommerce.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ResultDiscountCouponDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DiscountCouponList()
        {
            var values = await _discountService.GetAllDiscountCouponAsync();
            if (values == null || values.Count == 0)
                return NoContent();

            return Ok(ApiResponse<List<ResultDiscountCouponDto>>.Ok(values));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetByIdDiscountCouponDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDiscountCouponById(int id)
        {
            var values = await _discountService.GetByIdDiscountCouponAsync(id);
            if (values == null)
                return NotFound(ApiResponse.Fail(string.Format(ApiMessages.IdNotFound, id)));

            return Ok(ApiResponse<GetByIdDiscountCouponDto>.Ok(values));
        }
        [HttpGet("GetCodeDetailByCode")]
        [ProducesResponseType(typeof(ResultDiscountCouponDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCodeDetailByCode([FromQuery] string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return BadRequest(ApiResponse.Fail(ApiMessages.CodeRequired));

            var values = await _discountService.GetCodeDetailByCodeAsync(code);
            if (values == null)
                return NotFound(ApiResponse.Fail(string.Format(ApiMessages.CodeNotFound, code)));

            return Ok(ApiResponse<ResultDiscountCouponDto>.Ok(values));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateDiscountCoupon([FromBody] CreateDiscountCouponDto createCouponDto)
        {
            if (!ModelState.IsValid)
            {
                var modelErrors = string.Join("; ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return BadRequest(ApiResponse.Fail(modelErrors));
            }

            await _discountService.CreateDiscountCouponAsync(createCouponDto);

            // Return 201 Created with location to query by code
            if (!string.IsNullOrWhiteSpace(createCouponDto.CouponCode))
            {
                return CreatedAtAction(nameof(GetCodeDetailByCode), new { code = createCouponDto.CouponCode }, ApiResponse.Ok(ApiMessages.Created));
            }

            return StatusCode(StatusCodes.Status201Created, ApiResponse.Ok(ApiMessages.Created));

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
            await _discountService.DeleteDiscountCouponAsync(id);
            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateDiscountCoupon([FromBody] UpdateDiscountCouponDto updateCouponDto)
        {
            if (!ModelState.IsValid)
            {
                var modelErrors = string.Join("; ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return BadRequest(ApiResponse.Fail(modelErrors));
            }

            await _discountService.UpdateDiscountCouponAsync(updateCouponDto);
            return NoContent();
        }
    }
}

