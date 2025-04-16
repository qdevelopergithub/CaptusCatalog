using System;
using System.Collections.Generic;

namespace CaptusCatalog.Models;

public partial class ProformaInvoice
{
    public string Conf { get; set; } = null!;

    public int ContactId { get; set; }

    public int HomeAddressId { get; set; }

    public int? ShipAddressId { get; set; }

    public decimal? Total { get; set; }

    public decimal? ShippingTotal { get; set; }

    public string? ShippingType { get; set; }

    public string Currency { get; set; } = null!;

    public string? CcpaymentUrl { get; set; }

    public bool? IsBook { get; set; }

    public bool? IsComplete { get; set; }

    public bool? IsArchived { get; set; }

    public string? CouponCode { get; set; }

    public DateTime? Date { get; set; }

    public string? PaymentMethod { get; set; }

    public virtual Contact Contact { get; set; } = null!;

    public virtual Address HomeAddress { get; set; } = null!;

    public virtual ICollection<ProformaInvoiceItem> ProformaInvoiceItems { get; set; } = new List<ProformaInvoiceItem>();

    public virtual Address? ShipAddress { get; set; }
}
