namespace CaptusCatalog.Models
{
    /// <summary>
    /// Contains detailed results of tax calculation
    /// </summary>
    public class TaxCalculationResult
    {
        public string ItemId { get; set; }
        public decimal BaseAmount { get; set; }
        public decimal DiscountedAmount { get; set; }
        public decimal GstRate { get; set; }
        public decimal RstRate { get; set; }
        public decimal GstAmount { get; set; }
        public decimal RstAmount { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string TaxCategory { get; set; }
        public string Province { get; set; }
    }
}
