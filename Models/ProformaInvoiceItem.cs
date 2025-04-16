using System;
using System.Collections.Generic;

namespace CaptusCatalog.Models;

public partial class ProformaInvoiceItem
{
    public int Id { get; set; }

    public string? Conf { get; set; }

    public int Quantity { get; set; }

    public string ItemName { get; set; } = null!;

    public decimal Price { get; set; }

    public decimal Rst { get; set; }

    public decimal Hst { get; set; }

    public decimal? Total { get; set; }

    public virtual ProformaInvoice? ConfNavigation { get; set; }
}
