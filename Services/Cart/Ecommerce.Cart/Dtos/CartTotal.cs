namespace Ecommerce.Cart.Dtos
{
    public class CartTotal
    {
        public string UserId { get; set; }
        public string DiscountCode { get; set; }
        public int? DiscountRate { get; set; }
        public List<CartItemDto> CartItems { get; set; }
        public decimal TotalPrice { get => CartItems.Sum(x=>x.Price * x.Quantity);}
    }
}
