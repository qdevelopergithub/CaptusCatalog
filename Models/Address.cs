using System;
using System.Collections.Generic;

namespace CaptusCatalog.Models;

public partial class Address
{
    public int Id { get; set; }

    public string StreetAddress { get; set; } = null!;

    public string? Address2 { get; set; }

    public string City { get; set; } = null!;

    public string Province { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string? PostalCode { get; set; }

    public string Type { get; set; } = null!;

    public int? ContactId { get; set; }

    public string? DoorCode { get; set; }

    public string? Pobox { get; set; }

    public string? Organization { get; set; }

    public string? ShippingInstructions { get; set; }

    public string? RecipientName { get; set; }

    public virtual Contact? Contact { get; set; }

    public virtual ICollection<ProformaInvoice> ProformaInvoiceHomeAddresses { get; set; } = new List<ProformaInvoice>();

    public virtual ICollection<ProformaInvoice> ProformaInvoiceShipAddresses { get; set; } = new List<ProformaInvoice>();
}
