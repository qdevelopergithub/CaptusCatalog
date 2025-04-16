using System;
using System.Collections.Generic;

namespace CaptusCatalog.Models;

public partial class Contact
{
    public int Id { get; set; }

    public string First { get; set; } = null!;

    public string? Middle { get; set; }

    public string Last { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Phone2 { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<ProformaInvoice> ProformaInvoices { get; set; } = new List<ProformaInvoice>();
}
