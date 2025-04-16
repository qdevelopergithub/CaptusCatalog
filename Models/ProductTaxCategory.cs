using System;
using System.Collections.Generic;

namespace CaptusCatalog.Models;

public partial class ProductTaxCategory
{
    public int BookNumber { get; set; }

    public string TaxCategory { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Isbn { get; set; } = null!;

    public virtual ICollection<BookCoupon> BookCoupons { get; set; } = new List<BookCoupon>();

    public virtual ICollection<BookOrderItem> BookOrderItems { get; set; } = new List<BookOrderItem>();

    public virtual Catalogue? Catalogue { get; set; }
}
