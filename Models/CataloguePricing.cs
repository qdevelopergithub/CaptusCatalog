using System;
using System.Collections.Generic;

namespace CaptusCatalog.Models;

public partial class CataloguePricing
{
    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public string? Format { get; set; }

    public string Currency { get; set; } = null!;

    public decimal Price { get; set; }

    public double Weight { get; set; }

    public decimal PriceUs { get; set; }

    public int? UpdateCount { get; set; }

    public virtual Catalogue Book { get; set; } = null!;
}
