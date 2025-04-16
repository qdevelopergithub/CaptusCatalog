using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CaptusCatalog.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<BookCoupon> BookCoupons { get; set; }

    public virtual DbSet<BookOrderItem> BookOrderItems { get; set; }

    public virtual DbSet<Catalogitem> Catalogitems { get; set; }

    public virtual DbSet<Catalogue> Catalogues { get; set; }

    public virtual DbSet<CataloguePricing> CataloguePricings { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Dtproperty> Dtproperties { get; set; }

    public virtual DbSet<NetOrderResult> NetOrderResults { get; set; }

    public virtual DbSet<OnlineBookOrderInvoice> OnlineBookOrderInvoices { get; set; }

    public virtual DbSet<ProductTaxCategory> ProductTaxCategories { get; set; }

    public virtual DbSet<ProformaInvoice> ProformaInvoices { get; set; }

    public virtual DbSet<ProformaInvoiceItem> ProformaInvoiceItems { get; set; }

    public virtual DbSet<TaxRate> TaxRates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("Address", "Catalog");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address2)
                .HasMaxLength(1024)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.ContactId).HasColumnName("ContactID");
            entity.Property(e => e.Country)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.DoorCode)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.Organization)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Pobox)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("POBox");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.Province)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.RecipientName)
                .HasMaxLength(1024)
                .IsUnicode(false);
            entity.Property(e => e.ShippingInstructions)
                .HasMaxLength(1024)
                .IsUnicode(false);
            entity.Property(e => e.StreetAddress)
                .HasMaxLength(1024)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasDefaultValue("HOME");

            entity.HasOne(d => d.Contact).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.ContactId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Address_Contact");
        });

        modelBuilder.Entity<BookCoupon>(entity =>
        {
            entity.ToTable("BookCoupon", "Catalog");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CouponCode).HasMaxLength(50);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.Usvalue)
                .HasColumnType("money")
                .HasColumnName("USValue");
            entity.Property(e => e.Value).HasColumnType("money");

            entity.HasOne(d => d.BookNumberNavigation).WithMany(p => p.BookCoupons)
                .HasForeignKey(d => d.BookNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BookCoupon_ProductTaxCategory");
        });

        modelBuilder.Entity<BookOrderItem>(entity =>
        {
            entity.ToTable("BookOrderItems", "Catalog");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ConfirmationCode)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Gst)
                .HasDefaultValue(0.00m)
                .HasColumnType("money")
                .HasColumnName("GST");
            entity.Property(e => e.Hst)
                .HasDefaultValue(0.00m)
                .HasColumnType("money")
                .HasColumnName("HST");
            entity.Property(e => e.Isbn)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ISBN");
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.Rst)
                .HasDefaultValue(0.00m)
                .HasColumnType("money")
                .HasColumnName("RST");
            entity.Property(e => e.Title)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Usprice)
                .HasColumnType("money")
                .HasColumnName("USPrice");
            entity.Property(e => e.Weight).HasColumnType("numeric(18, 3)");

            entity.HasOne(d => d.BookNumberNavigation).WithMany(p => p.BookOrderItems)
                .HasForeignKey(d => d.BookNumber)
                .HasConstraintName("FK_BookOrderItems_ProductTaxCategory");
        });

        modelBuilder.Entity<Catalogitem>(entity =>
        {
            entity.HasKey(e => e.BookNumber);

            entity.ToTable("catalogitems", "Catalog");

            entity.Property(e => e.BookNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.AboutTheAuthor).HasColumnType("text");
            entity.Property(e => e.AddImageLink)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.AddeBookLink)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.AuthorEditor)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.AuthorEditor2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.AuthorEditor3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.BookSubtitle)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.BookTitle)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Comma1)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.Comma2)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.Comma3)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.CoverLink)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.DetailedToc)
                .HasColumnType("text")
                .HasColumnName("DetailedTOC");
            entity.Property(e => e.EBookPriceCan)
                .HasMaxLength(68)
                .IsUnicode(false)
                .HasColumnName("eBookPriceCan");
            entity.Property(e => e.Etal)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("etal");
            entity.Property(e => e.Features).HasColumnType("text");
            entity.Property(e => e.GramsCat)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.Hardcover)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.Imprint)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.InstructorResources).HasColumnType("text");
            entity.Property(e => e.Isbn)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("ISBN");
            entity.Property(e => e.PagesCat)
                .HasMaxLength(37)
                .IsUnicode(false);
            entity.Property(e => e.Preview)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Publisher)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.PurchaseTheBook)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.RelatedResources).HasColumnType("text");
            entity.Property(e => e.RetailPriceCanCat)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RetailPriceForCat)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RoleCat)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.SeriesCat)
                .HasMaxLength(65)
                .IsUnicode(false);
            entity.Property(e => e.Shinternal).HasColumnName("SHInternal");
            entity.Property(e => e.Size)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.StatusCat)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.SubTitleCat)
                .HasMaxLength(133)
                .IsUnicode(false);
            entity.Property(e => e.Testimonials).HasColumnType("text");
            entity.Property(e => e.TitleCat)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.TitleLink)
                .HasMaxLength(178)
                .IsUnicode(false);
            entity.Property(e => e.Toc)
                .HasColumnType("text")
                .HasColumnName("TOC");
            entity.Property(e => e.Topic)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Topic2)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Topic3)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.TopicList).HasColumnType("text");
            entity.Property(e => e.Updates).HasColumnType("text");
            entity.Property(e => e.YearOfPublication)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Catalogue>(entity =>
        {
            entity.HasKey(e => e.BookNumber);

            entity.ToTable("Catalogue", "Catalog");

            entity.Property(e => e.BookNumber).ValueGeneratedNever();
            entity.Property(e => e.AboutAuthor).HasColumnType("text");
            entity.Property(e => e.Author)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.BindingType)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Feedable).HasDefaultValue(true);
            entity.Property(e => e.Image)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Imprint)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.InstructorResources).HasColumnType("text");
            entity.Property(e => e.Isbn)
                .HasMaxLength(48)
                .IsUnicode(false)
                .HasColumnName("ISBN");
            entity.Property(e => e.Linkable).HasDefaultValue(true);
            entity.Property(e => e.Publisher)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.Purchasable).HasDefaultValue(true);
            entity.Property(e => e.Rawisbn)
                .HasMaxLength(48)
                .IsUnicode(false)
                .HasColumnName("RAWISBN");
            entity.Property(e => e.RelatedResources).HasColumnType("text");
            entity.Property(e => e.Searchable).HasDefaultValue(true);
            entity.Property(e => e.Series)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Size)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.SubTitleCat)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Subtitle)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Toc)
                .HasColumnType("text")
                .HasColumnName("TOC");
            entity.Property(e => e.Topic)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.YearPublished)
                .HasMaxLength(32)
                .IsUnicode(false);

            entity.HasOne(d => d.BookNumberNavigation).WithOne(p => p.Catalogue)
                .HasForeignKey<Catalogue>(d => d.BookNumber)
                .HasConstraintName("FK_Catalogue_ProductTaxCategory");
        });

        modelBuilder.Entity<CataloguePricing>(entity =>
        {
            entity.HasKey(e => e.BookId);

            entity.ToTable("CataloguePricing", "Catalog");

            entity.Property(e => e.BookId)
                .ValueGeneratedNever()
                .HasColumnName("BookID");
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("CAD");
            entity.Property(e => e.Format)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.Price)
                .HasDefaultValue(-1m)
                .HasColumnType("money");
            entity.Property(e => e.PriceUs)
                .HasDefaultValue(-1m)
                .HasColumnType("money")
                .HasColumnName("PriceUS");
            entity.Property(e => e.Title)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Weight).HasDefaultValue(-1.0);

            entity.HasOne(d => d.Book).WithOne(p => p.CataloguePricing)
                .HasForeignKey<CataloguePricing>(d => d.BookId)
                .HasConstraintName("FK_CataloguePricing_Catalogue");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.ToTable("Contact", "Catalog");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.First)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.Last)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.Middle)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.Phone2)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Dtproperty>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.Property });

            entity.ToTable("dtproperties", "Catalog");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Property)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("property");
            entity.Property(e => e.Lvalue)
                .HasColumnType("image")
                .HasColumnName("lvalue");
            entity.Property(e => e.Objectid).HasColumnName("objectid");
            entity.Property(e => e.Uvalue)
                .HasMaxLength(255)
                .HasColumnName("uvalue");
            entity.Property(e => e.Value)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("value");
            entity.Property(e => e.Version).HasColumnName("version");
        });

        modelBuilder.Entity<NetOrderResult>(entity =>
        {
            entity.HasKey(e => e.ConfirmationCode);

            entity.ToTable("NetOrderResults", "Catalog");

            entity.Property(e => e.ConfirmationCode)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.BillingAddress1)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.BillingAddress2)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.BillingCity)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.BillingCountry)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.BillingSameShipping)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.BillingState)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.BillingZip)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("BillingZIP");
            entity.Property(e => e.BrowserType)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("Browser_type");
            entity.Property(e => e.CardholderName)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.Comments)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.Costperbook1a)
                .HasColumnType("money")
                .HasColumnName("costperbook1a");
            entity.Property(e => e.Costperbook2a)
                .HasColumnType("money")
                .HasColumnName("costperbook2a");
            entity.Property(e => e.Costperbook3a)
                .HasColumnType("money")
                .HasColumnName("costperbook3a");
            entity.Property(e => e.Costperbook4a)
                .HasColumnType("money")
                .HasColumnName("costperbook4a");
            entity.Property(e => e.Costperbook5a)
                .HasColumnType("money")
                .HasColumnName("costperbook5a");
            entity.Property(e => e.Costperbook6a)
                .HasColumnType("money")
                .HasColumnName("costperbook6a");
            entity.Property(e => e.Costperbook7a)
                .HasColumnType("money")
                .HasColumnName("costperbook7a");
            entity.Property(e => e.Costperbook8a)
                .HasColumnType("money")
                .HasColumnName("costperbook8a");
            entity.Property(e => e.Country)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.CouponId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CouponID");
            entity.Property(e => e.CourierDelivery)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("Courier_Delivery");
            entity.Property(e => e.CreditCardExpirationDate)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreditCardNumber)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.CreditCardType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Currencya)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("EMailAddress");
            entity.Property(e => e.EmailTo)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("EMAIL_TO");
            entity.Property(e => e.GrandTotala).HasColumnType("money");
            entity.Property(e => e.Gsthsta).HasColumnName("GSTHSTa");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IfError)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("if_error");
            entity.Property(e => e.LearnFrom)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.LearnFromOther)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.Organization)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.PaymentOption)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Qty1a).HasColumnName("qty1a");
            entity.Property(e => e.Qty2a).HasColumnName("qty2a");
            entity.Property(e => e.Qty3a).HasColumnName("qty3a");
            entity.Property(e => e.Qty4a).HasColumnName("qty4a");
            entity.Property(e => e.Qty5a).HasColumnName("qty5a");
            entity.Property(e => e.Qty6a).HasColumnName("qty6a");
            entity.Property(e => e.Qty7a).HasColumnName("qty7a");
            entity.Property(e => e.Qty8a).HasColumnName("qty8a");
            entity.Property(e => e.QtyShip1).HasColumnName("qtyShip1");
            entity.Property(e => e.QtyShip2).HasColumnName("qtyShip2");
            entity.Property(e => e.QtyShip3).HasColumnName("qtyShip3");
            entity.Property(e => e.QtyShip4).HasColumnName("qtyShip4");
            entity.Property(e => e.QtyShip5).HasColumnName("qtyShip5");
            entity.Property(e => e.QtyShip6).HasColumnName("qtyShip6");
            entity.Property(e => e.QtyShip7).HasColumnName("qtyShip7");
            entity.Property(e => e.QtyShip8).HasColumnName("qtyShip8");
            entity.Property(e => e.Redirect)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("redirect");
            entity.Property(e => e.RemoteComputerName)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("Remote_computer_name");
            entity.Property(e => e.SalesTaxa).HasColumnType("money");
            entity.Property(e => e.ShippingAddress1)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.ShippingAddress2)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.ShippingCharge).HasColumnType("money");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SubTotala).HasColumnType("money");
            entity.Property(e => e.TaxTotal).HasColumnType("money");
            entity.Property(e => e.Telephone)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.Timestamp).HasColumnType("datetime");
            entity.Property(e => e.Title1a)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.Title2a)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.Title3a)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.Title4a)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.Title5a)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.Title6a)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.Title7a)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.Title8a)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.TotalBookPrice).HasColumnType("money");
            entity.Property(e => e.TotalPst)
                .HasColumnType("money")
                .HasColumnName("TotalPST");
            entity.Property(e => e.UserName)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("User_name");
            entity.Property(e => e.Weightperbook1a).HasColumnName("weightperbook1a");
            entity.Property(e => e.Weightperbook2a).HasColumnName("weightperbook2a");
            entity.Property(e => e.Weightperbook3a).HasColumnName("weightperbook3a");
            entity.Property(e => e.Weightperbook4a).HasColumnName("weightperbook4a");
            entity.Property(e => e.Weightperbook5a).HasColumnName("weightperbook5a");
            entity.Property(e => e.Weightperbook6a).HasColumnName("weightperbook6a");
            entity.Property(e => e.Weightperbook7a).HasColumnName("weightperbook7a");
            entity.Property(e => e.Weightperbook8a).HasColumnName("weightperbook8a");
            entity.Property(e => e.Zip)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ZIP");
        });

        modelBuilder.Entity<OnlineBookOrderInvoice>(entity =>
        {
            entity.HasKey(e => e.ConfirmationNumber);

            entity.ToTable("OnlineBookOrderInvoice", "Catalog");

            entity.Property(e => e.ConfirmationNumber)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.BalanceDue).HasColumnType("money");
            entity.Property(e => e.BillingAddress1)
                .HasMaxLength(48)
                .IsUnicode(false);
            entity.Property(e => e.BillingAddress2)
                .HasMaxLength(48)
                .IsUnicode(false);
            entity.Property(e => e.BillingCity)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.BillingCountry)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.BillingState)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.BillingZip)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.CardholderName)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.CouponId)
                .HasMaxLength(24)
                .IsUnicode(false)
                .HasColumnName("CouponID");
            entity.Property(e => e.CourierDelivery)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("Courier_Delivery");
            entity.Property(e => e.CreditCardType)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.DateShipped).HasColumnType("datetime");
            entity.Property(e => e.DollarType)
                .HasMaxLength(18)
                .IsUnicode(false);
            entity.Property(e => e.GsthstonAllItems)
                .HasColumnType("money")
                .HasColumnName("GSTHSTOnAllItems");
            entity.Property(e => e.Isbn1)
                .HasMaxLength(24)
                .IsUnicode(false)
                .HasColumnName("ISBN1");
            entity.Property(e => e.Isbn2)
                .HasMaxLength(24)
                .IsUnicode(false)
                .HasColumnName("ISBN2");
            entity.Property(e => e.Isbn3)
                .HasMaxLength(24)
                .IsUnicode(false)
                .HasColumnName("ISBN3");
            entity.Property(e => e.Isbn4)
                .HasMaxLength(24)
                .IsUnicode(false)
                .HasColumnName("ISBN4");
            entity.Property(e => e.Isbn5)
                .HasMaxLength(24)
                .IsUnicode(false)
                .HasColumnName("ISBN5");
            entity.Property(e => e.Isbn6)
                .HasMaxLength(24)
                .IsUnicode(false)
                .HasColumnName("ISBN6");
            entity.Property(e => e.Isbn7)
                .HasMaxLength(24)
                .IsUnicode(false)
                .HasColumnName("ISBN7");
            entity.Property(e => e.Isbn8)
                .HasMaxLength(24)
                .IsUnicode(false)
                .HasColumnName("ISBN8");
            entity.Property(e => e.ItemTotal1).HasColumnType("money");
            entity.Property(e => e.ItemTotal2).HasColumnType("money");
            entity.Property(e => e.ItemTotal3).HasColumnType("money");
            entity.Property(e => e.ItemTotal4).HasColumnType("money");
            entity.Property(e => e.ItemTotal5).HasColumnType("money");
            entity.Property(e => e.ItemTotal6).HasColumnType("money");
            entity.Property(e => e.ItemTotal7).HasColumnType("money");
            entity.Property(e => e.ItemTotal8).HasColumnType("money");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.OrderNumber)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.Organization)
                .HasMaxLength(48)
                .IsUnicode(false);
            entity.Property(e => e.PaymentOption)
                .HasMaxLength(28)
                .IsUnicode(false);
            entity.Property(e => e.PaymentRcdRebate).HasColumnType("money");
            entity.Property(e => e.Price1).HasColumnType("money");
            entity.Property(e => e.Price2).HasColumnType("money");
            entity.Property(e => e.Price3).HasColumnType("money");
            entity.Property(e => e.Price4).HasColumnType("money");
            entity.Property(e => e.Price5).HasColumnType("money");
            entity.Property(e => e.Price6).HasColumnType("money");
            entity.Property(e => e.Price7).HasColumnType("money");
            entity.Property(e => e.Price8).HasColumnType("money");
            entity.Property(e => e.Qty1a).HasColumnName("qty1a");
            entity.Property(e => e.Qty2a).HasColumnName("qty2a");
            entity.Property(e => e.Qty3a).HasColumnName("qty3a");
            entity.Property(e => e.Qty4a).HasColumnName("qty4a");
            entity.Property(e => e.Qty5a).HasColumnName("qty5a");
            entity.Property(e => e.Qty6a).HasColumnName("qty6a");
            entity.Property(e => e.Qty7a).HasColumnName("qty7a");
            entity.Property(e => e.Qty8a).HasColumnName("qty8a");
            entity.Property(e => e.Remark)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Shipping).HasColumnType("money");
            entity.Property(e => e.ShippingAddress1)
                .HasMaxLength(48)
                .IsUnicode(false);
            entity.Property(e => e.ShippingCity)
                .HasMaxLength(48)
                .IsUnicode(false);
            entity.Property(e => e.ShippingCountry)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.ShippingMethod)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.ShippingState)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.ShippingZip)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Subtotal).HasColumnType("money");
            entity.Property(e => e.Timestamp).HasColumnType("datetime");
            entity.Property(e => e.Title1a)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Title2a)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Title3a)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Title4a)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Title5a)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Title6a)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Title7a)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Title8a)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.TotalAmountDue).HasColumnType("money");
            entity.Property(e => e.TotalGsthstfromThisForm)
                .HasColumnType("money")
                .HasColumnName("TotalGSTHSTFromThisForm");
        });

        modelBuilder.Entity<ProductTaxCategory>(entity =>
        {
            entity.HasKey(e => e.BookNumber);

            entity.ToTable("ProductTaxCategory", "Catalog");

            entity.Property(e => e.BookNumber).ValueGeneratedNever();
            entity.Property(e => e.Isbn)
                .HasMaxLength(24)
                .IsUnicode(false)
                .HasColumnName("ISBN");
            entity.Property(e => e.TaxCategory)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(180)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProformaInvoice>(entity =>
        {
            entity.HasKey(e => e.Conf);

            entity.ToTable("ProformaInvoice", "Catalog");

            entity.Property(e => e.Conf)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.CcpaymentUrl)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("CCPaymentURL");
            entity.Property(e => e.ContactId).HasColumnName("ContactID");
            entity.Property(e => e.CouponCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Currency)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValue("USD");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.HomeAddressId).HasColumnName("HomeAddressID");
            entity.Property(e => e.IsArchived).HasDefaultValue(false);
            entity.Property(e => e.IsBook).HasDefaultValue(false);
            entity.Property(e => e.IsComplete).HasDefaultValue(false);
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.ShipAddressId).HasColumnName("ShipAddressID");
            entity.Property(e => e.ShippingTotal).HasColumnType("money");
            entity.Property(e => e.ShippingType)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.Total).HasColumnType("money");

            entity.HasOne(d => d.Contact).WithMany(p => p.ProformaInvoices)
                .HasForeignKey(d => d.ContactId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProformaInvoice_Contact");

            entity.HasOne(d => d.HomeAddress).WithMany(p => p.ProformaInvoiceHomeAddresses)
                .HasForeignKey(d => d.HomeAddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProformaInvoice_HomeAddress");

            entity.HasOne(d => d.ShipAddress).WithMany(p => p.ProformaInvoiceShipAddresses)
                .HasForeignKey(d => d.ShipAddressId)
                .HasConstraintName("FK_ProformaInvoice_ShipAddress");
        });

        modelBuilder.Entity<ProformaInvoiceItem>(entity =>
        {
            entity.ToTable("ProformaInvoiceItem", "Catalog");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Conf)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Hst)
                .HasColumnType("money")
                .HasColumnName("HST");
            entity.Property(e => e.ItemName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.Quantity).HasDefaultValue(1);
            entity.Property(e => e.Rst)
                .HasColumnType("money")
                .HasColumnName("RST");
            entity.Property(e => e.Total).HasColumnType("money");

            entity.HasOne(d => d.ConfNavigation).WithMany(p => p.ProformaInvoiceItems)
                .HasForeignKey(d => d.Conf)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ProformaInvoiceItem_ProformaInvoice");
        });

        modelBuilder.Entity<TaxRate>(entity =>
        {
            entity.HasKey(e => new { e.Province, e.TaxCategory });

            entity.ToTable("TaxRates", "Catalog");

            entity.Property(e => e.Province)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.TaxCategory)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gst).HasColumnName("GST");
            entity.Property(e => e.Label)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Rst).HasColumnName("RST");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
