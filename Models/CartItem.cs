namespace CaptusCatalog.Models
{
    /// <summary>
    /// Represents an item in a shopping cart
    /// </summary>
    public class CartItem
    {
        public string ItemId { get; set; }
        public int BookNumber { get; set; }
        public decimal Price { get; set; }
        public decimal? CouponAmount { get; set; }
    }

}
