using System;
using System.Collections.Generic;

namespace CaptusCatalog.Models;

public partial class NetOrderResult
{
    public int? Id { get; set; }

    public string ConfirmationCode { get; set; } = null!;

    public string? Name { get; set; }

    public string? Organization { get; set; }

    public string? EmailAddress { get; set; }

    public string? Telephone { get; set; }

    public string? CourierDelivery { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }

    public string? Country { get; set; }

    public string? BillingAddress1 { get; set; }

    public string? BillingAddress2 { get; set; }

    public string? PaymentOption { get; set; }

    public string? CreditCardType { get; set; }

    public string? CardholderName { get; set; }

    public string? CreditCardNumber { get; set; }

    public string? CreditCardExpirationDate { get; set; }

    public string? CouponId { get; set; }

    public string? LearnFrom { get; set; }

    public string? LearnFromOther { get; set; }

    public string? Comments { get; set; }

    public string? RemoteComputerName { get; set; }

    public string? UserName { get; set; }

    public string? BrowserType { get; set; }

    public DateTime? Timestamp { get; set; }

    public string? EmailTo { get; set; }

    public string? Redirect { get; set; }

    public string? IfError { get; set; }

    public string? BillingCity { get; set; }

    public string? BillingState { get; set; }

    public string? BillingZip { get; set; }

    public string? BillingCountry { get; set; }

    public decimal? Costperbook1a { get; set; }

    public string? Title1a { get; set; }

    public double? Weightperbook1a { get; set; }

    public decimal? Costperbook2a { get; set; }

    public string? Title2a { get; set; }

    public double? Weightperbook2a { get; set; }

    public decimal? Costperbook3a { get; set; }

    public string? Title3a { get; set; }

    public double? Weightperbook3a { get; set; }

    public decimal? Costperbook4a { get; set; }

    public string? Title4a { get; set; }

    public double? Weightperbook4a { get; set; }

    public decimal? Costperbook5a { get; set; }

    public string? Title5a { get; set; }

    public double? Weightperbook5a { get; set; }

    public decimal? Costperbook6a { get; set; }

    public string? Title6a { get; set; }

    public double? Weightperbook6a { get; set; }

    public decimal? Costperbook7a { get; set; }

    public string? Title7a { get; set; }

    public double? Weightperbook7a { get; set; }

    public decimal? Costperbook8a { get; set; }

    public string? Title8a { get; set; }

    public double? Weightperbook8a { get; set; }

    public int? Qty1a { get; set; }

    public int? Qty2a { get; set; }

    public int? Qty3a { get; set; }

    public int? Qty4a { get; set; }

    public int? Qty5a { get; set; }

    public int? Qty6a { get; set; }

    public int? Qty7a { get; set; }

    public int? Qty8a { get; set; }

    public int? QtyShip1 { get; set; }

    public int? QtyShip2 { get; set; }

    public int? QtyShip3 { get; set; }

    public int? QtyShip4 { get; set; }

    public int? QtyShip5 { get; set; }

    public int? QtyShip6 { get; set; }

    public int? QtyShip7 { get; set; }

    public int? QtyShip8 { get; set; }

    public double? TotalWeight { get; set; }

    public decimal? TotalBookPrice { get; set; }

    public double? CouponValue { get; set; }

    public decimal? TotalPst { get; set; }

    public string? ShippingAddress2 { get; set; }

    public string? BillingSameShipping { get; set; }

    public string? ShippingAddress1 { get; set; }

    public decimal? ShippingCharge { get; set; }

    public string? Currencya { get; set; }

    public decimal? SubTotala { get; set; }

    public decimal? SalesTaxa { get; set; }

    public decimal? TaxTotal { get; set; }

    public double? Gsthsta { get; set; }

    public double? ShippingTaxa { get; set; }

    public decimal? GrandTotala { get; set; }
}
