using System;
using System.Collections.Generic;

namespace CaptusCatalog.Models;

public partial class Catalogue
{
    public int BookNumber { get; set; }

    public string? Subtitle { get; set; }

    public string? Publisher { get; set; }

    public string? Topic { get; set; }

    public string? Author { get; set; }

    public string? Isbn { get; set; }

    public string? Rawisbn { get; set; }

    public string? BindingType { get; set; }

    public string? YearPublished { get; set; }

    public string? Imprint { get; set; }

    public string? Size { get; set; }

    public string? Description { get; set; }

    public string? Toc { get; set; }

    public string? InstructorResources { get; set; }

    public string? RelatedResources { get; set; }

    public string? AboutAuthor { get; set; }

    public string? Image { get; set; }

    public int? Pages { get; set; }

    public string? Title { get; set; }

    public string? SubTitleCat { get; set; }

    public string? Series { get; set; }

    public bool Searchable { get; set; }

    public bool Feedable { get; set; }

    public bool Purchasable { get; set; }

    public bool Linkable { get; set; }

    public virtual ProductTaxCategory BookNumberNavigation { get; set; } = null!;

    public virtual CataloguePricing? CataloguePricing { get; set; }
}
