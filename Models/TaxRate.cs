using System;
using System.Collections.Generic;

namespace CaptusCatalog.Models;

public partial class TaxRate
{
    public string Province { get; set; } = null!;

    public string TaxCategory { get; set; } = null!;

    public double? Rst { get; set; }

    public double? Gst { get; set; }

    public string? Label { get; set; }
}
