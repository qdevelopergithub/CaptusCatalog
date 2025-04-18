using CaptusCatalog.Services;

namespace CaptusCatalog.Models
{
    public class CartTaxRequest
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public string Province { get; set; } = string.Empty;
        public string Country { get; set; } = "CA";
    }
}
