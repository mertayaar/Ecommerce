namespace Ecommerce.Discount.Dtos
{
    public class GetByIDDiscountCouponDto
    {
        public int CouponID { get; set; }
        public string CouponCode { get; set; }
        public int CouponRate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
