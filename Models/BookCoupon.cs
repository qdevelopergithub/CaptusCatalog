using System;
using System.Collections.Generic;

namespace CaptusCatalog.Models;

public partial class BookCoupon
{
    public int Id { get; set; }

    public int BookNumber { get; set; }

    public decimal Value { get; set; }

    public decimal Usvalue { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string CouponCode { get; set; } = null!;

    public virtual ProductTaxCategory BookNumberNavigation { get; set; } = null!;
}
