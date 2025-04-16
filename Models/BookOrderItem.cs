using System;
using System.Collections.Generic;

namespace CaptusCatalog.Models;

public partial class BookOrderItem
{
    public int Id { get; set; }

    public string ConfirmationCode { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Isbn { get; set; } = null!;

    public decimal Price { get; set; }

    public int? BookNumber { get; set; }

    public decimal? Usprice { get; set; }

    public decimal Weight { get; set; }

    public int Quantity { get; set; }

    public int? OrderQty { get; set; }

    public decimal? Gst { get; set; }

    public decimal? Rst { get; set; }

    public decimal? Hst { get; set; }

    public virtual ProductTaxCategory? BookNumberNavigation { get; set; }
}
