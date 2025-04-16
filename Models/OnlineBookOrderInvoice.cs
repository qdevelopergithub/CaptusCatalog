using System;
using System.Collections.Generic;

namespace CaptusCatalog.Models;

public partial class OnlineBookOrderInvoice
{
    public string ConfirmationNumber { get; set; } = null!;

    public string? OrderNumber { get; set; }

    public string? Name { get; set; }

    public string? Organization { get; set; }

    public string? BillingAddress1 { get; set; }

    public string? BillingAddress2 { get; set; }

    public string? BillingCity { get; set; }

    public string? BillingState { get; set; }

    public string? BillingCountry { get; set; }

    public string? BillingZip { get; set; }

    public string? PaymentOption { get; set; }

    public DateTime? Timestamp { get; set; }

    public int? Qty1a { get; set; }

    public string? Title1a { get; set; }

    public int? Qty2a { get; set; }

    public string? Title2a { get; set; }

    public int? Qty3a { get; set; }

    public string? Title3a { get; set; }

    public int? Qty4a { get; set; }

    public string? Title4a { get; set; }

    public int? Qty5a { get; set; }

    public string? Title5a { get; set; }

    public int? Qty6a { get; set; }

    public string? Title6a { get; set; }

    public int? Qty7a { get; set; }

    public string? Title7a { get; set; }

    public int? Qty8a { get; set; }

    public string? Title8a { get; set; }

    public string? Isbn1 { get; set; }

    public int? Shpd1 { get; set; }

    public int? Shpd2 { get; set; }

    public int? Shpd3 { get; set; }

    public int? Shpd4 { get; set; }

    public int? Shpd5 { get; set; }

    public int? Shpd6 { get; set; }

    public int? Shpd7 { get; set; }

    public int? Shpd8 { get; set; }

    public string? Isbn2 { get; set; }

    public string? Isbn3 { get; set; }

    public string? Isbn4 { get; set; }

    public string? Isbn5 { get; set; }

    public string? Isbn6 { get; set; }

    public string? Isbn7 { get; set; }

    public string? Isbn8 { get; set; }

    public decimal? GsthstonAllItems { get; set; }

    public decimal? Shipping { get; set; }

    public decimal? TotalAmountDue { get; set; }

    public decimal? PaymentRcdRebate { get; set; }

    public int InvoiceNumber { get; set; }

    public string? CourierDelivery { get; set; }

    public string? ShippingAddress1 { get; set; }

    public string? ShippingCity { get; set; }

    public string? ShippingState { get; set; }

    public string? ShippingZip { get; set; }

    public string? ShippingCountry { get; set; }

    public string? CreditCardType { get; set; }

    public string? CardholderName { get; set; }

    public string? CouponId { get; set; }

    public decimal? Price1 { get; set; }

    public decimal? Price2 { get; set; }

    public decimal? Price3 { get; set; }

    public decimal? Price4 { get; set; }

    public decimal? Price5 { get; set; }

    public decimal? Price6 { get; set; }

    public decimal? Price7 { get; set; }

    public decimal? Price8 { get; set; }

    public decimal? TotalGsthstfromThisForm { get; set; }

    public decimal? ItemTotal1 { get; set; }

    public decimal? ItemTotal2 { get; set; }

    public decimal? ItemTotal3 { get; set; }

    public decimal? ItemTotal4 { get; set; }

    public decimal? ItemTotal5 { get; set; }

    public decimal? ItemTotal6 { get; set; }

    public decimal? ItemTotal7 { get; set; }

    public decimal? ItemTotal8 { get; set; }

    public decimal? BalanceDue { get; set; }

    public decimal? Subtotal { get; set; }

    public string? ShippingMethod { get; set; }

    public string? Remark { get; set; }

    public int? BkOrd1 { get; set; }

    public int? BkOrd2 { get; set; }

    public int? BkOrd3 { get; set; }

    public int? BkOrd4 { get; set; }

    public int? BkOrd5 { get; set; }

    public int? BkOrd6 { get; set; }

    public int? BkOrd7 { get; set; }

    public int? BkOrd8 { get; set; }

    public DateTime? DateShipped { get; set; }

    public string? DollarType { get; set; }
}
