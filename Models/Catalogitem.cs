using System;
using System.Collections.Generic;

namespace CaptusCatalog.Models;

public partial class Catalogitem
{
    public string BookNumber { get; set; } = null!;

    public string? BookSubtitle { get; set; }

    public string? Publisher { get; set; }

    public string? Topic { get; set; }

    public string? AuthorEditor { get; set; }

    public string? AuthorEditor2 { get; set; }

    public string? AuthorEditor3 { get; set; }

    public string? Isbn { get; set; }

    public string? Hardcover { get; set; }

    public string? YearOfPublication { get; set; }

    public string? Imprint { get; set; }

    public string? Etal { get; set; }

    public string? Size { get; set; }

    public string? Comma1 { get; set; }

    public string? Comma2 { get; set; }

    public string? Comma3 { get; set; }

    public string? RetailPriceCanCat { get; set; }

    public string? RetailPriceForCat { get; set; }

    public string? Description { get; set; }

    public string? Toc { get; set; }

    public string? InstructorResources { get; set; }

    public string? RelatedResources { get; set; }

    public string? AboutTheAuthor { get; set; }

    public string? PurchaseTheBook { get; set; }

    public string? CoverLink { get; set; }

    public string? AddImageLink { get; set; }

    public string? PagesCat { get; set; }

    public string? GramsCat { get; set; }

    public string? StatusCat { get; set; }

    public string? TitleCat { get; set; }

    public string? Topic2 { get; set; }

    public string? Topic3 { get; set; }

    public string? TitleLink { get; set; }

    public string? RoleCat { get; set; }

    public string? SubTitleCat { get; set; }

    public string? SeriesCat { get; set; }

    public string? BookTitle { get; set; }

    public string? AddeBookLink { get; set; }

    public string? EBookPriceCan { get; set; }

    public DateTime? DateModified { get; set; }

    public string? DetailedToc { get; set; }

    public string? Features { get; set; }

    public string? Preview { get; set; }

    public double? Shinternal { get; set; }

    public string? Testimonials { get; set; }

    public string? Updates { get; set; }

    public string? TopicList { get; set; }
}
