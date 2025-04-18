using CaptusCatalog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CaptusCatalog.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            try
            {
                // Ensure the database is created
                context.Database.EnsureCreated();
                Console.WriteLine("Database created or already exists.");

                // Initialize tax rates for all provinces if they don't exist
                InitializeTaxRates(context);

                // Initialize product tax categories if they don't exist
                InitializeProductTaxCategories(context);

                // Initialize coupons if they don't exist
                InitializeCoupons(context);

                Console.WriteLine("Database initialization completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during database initialization: {ex.Message}");
                // We'll continue anyway since the application might still work with existing data
            }
        }

        private static void InitializeTaxRates(ApplicationDbContext context)
        {
            // Check if BC exists - our test for whether all provinces are added
            if (!context.TaxRates.Any(tr => tr.Province == "BC"))
            {
                Console.WriteLine("Adding tax rates for all provinces...");
                
                try
                {
                    // Delete all existing tax rates if they exist
                    if (context.TaxRates.Any())
                    {
                        Console.WriteLine("Removing existing tax rates...");
                        context.TaxRates.RemoveRange(context.TaxRates);
                        context.SaveChanges();
                    }

                    // Add tax rates with all provinces
                    var taxRates = new TaxRate[]
                    {
                        // Ontario (ON)
                        new TaxRate { Province = "ON", TaxCategory = "BOOK", Rst = 0.08, Gst = 0.05 },
                        new TaxRate { Province = "ON", TaxCategory = "EBOOK", Rst = 0.08, Gst = 0.05 },
                        new TaxRate { Province = "ON", TaxCategory = "OTHER1", Rst = 0.08, Gst = 0.05 },
                        new TaxRate { Province = "ON", TaxCategory = "OTHER2", Rst = 0.08, Gst = 0.05 },
                        
                        // Quebec (QC)
                        new TaxRate { Province = "QC", TaxCategory = "BOOK", Rst = 0.09975, Gst = 0.05 },
                        new TaxRate { Province = "QC", TaxCategory = "EBOOK", Rst = 0.09975, Gst = 0.05 },
                        new TaxRate { Province = "QC", TaxCategory = "OTHER1", Rst = 0.09975, Gst = 0.05 },
                        new TaxRate { Province = "QC", TaxCategory = "OTHER2", Rst = 0.09975, Gst = 0.05 },
                        
                        // Alberta (AB)
                        new TaxRate { Province = "AB", TaxCategory = "BOOK", Rst = 0.0, Gst = 0.05 },
                        new TaxRate { Province = "AB", TaxCategory = "EBOOK", Rst = 0.0, Gst = 0.05 },
                        new TaxRate { Province = "AB", TaxCategory = "OTHER1", Rst = 0.0, Gst = 0.05 },
                        new TaxRate { Province = "AB", TaxCategory = "OTHER2", Rst = 0.0, Gst = 0.05 },
                        
                        // British Columbia (BC)
                        new TaxRate { Province = "BC", TaxCategory = "BOOK", Rst = 0.07, Gst = 0.05 },
                        new TaxRate { Province = "BC", TaxCategory = "EBOOK", Rst = 0.07, Gst = 0.05 },
                        new TaxRate { Province = "BC", TaxCategory = "OTHER1", Rst = 0.07, Gst = 0.05 },
                        new TaxRate { Province = "BC", TaxCategory = "OTHER2", Rst = 0.07, Gst = 0.05 },
                        
                        // Manitoba (MB)
                        new TaxRate { Province = "MB", TaxCategory = "BOOK", Rst = 0.07, Gst = 0.05 },
                        new TaxRate { Province = "MB", TaxCategory = "EBOOK", Rst = 0.07, Gst = 0.05 },
                        new TaxRate { Province = "MB", TaxCategory = "OTHER1", Rst = 0.07, Gst = 0.05 },
                        new TaxRate { Province = "MB", TaxCategory = "OTHER2", Rst = 0.07, Gst = 0.05 },
                        
                        // New Brunswick (NB)
                        new TaxRate { Province = "NB", TaxCategory = "BOOK", Rst = 0.10, Gst = 0.05 },
                        new TaxRate { Province = "NB", TaxCategory = "EBOOK", Rst = 0.10, Gst = 0.05 },
                        new TaxRate { Province = "NB", TaxCategory = "OTHER1", Rst = 0.10, Gst = 0.05 },
                        new TaxRate { Province = "NB", TaxCategory = "OTHER2", Rst = 0.10, Gst = 0.05 },
                        
                        // Newfoundland and Labrador (NL)
                        new TaxRate { Province = "NL", TaxCategory = "BOOK", Rst = 0.10, Gst = 0.05 },
                        new TaxRate { Province = "NL", TaxCategory = "EBOOK", Rst = 0.10, Gst = 0.05 },
                        new TaxRate { Province = "NL", TaxCategory = "OTHER1", Rst = 0.10, Gst = 0.05 },
                        new TaxRate { Province = "NL", TaxCategory = "OTHER2", Rst = 0.10, Gst = 0.05 },
                        
                        // Northwest Territories (NT)
                        new TaxRate { Province = "NT", TaxCategory = "BOOK", Rst = 0.0, Gst = 0.05 },
                        new TaxRate { Province = "NT", TaxCategory = "EBOOK", Rst = 0.0, Gst = 0.05 },
                        new TaxRate { Province = "NT", TaxCategory = "OTHER1", Rst = 0.0, Gst = 0.05 },
                        new TaxRate { Province = "NT", TaxCategory = "OTHER2", Rst = 0.0, Gst = 0.05 },
                        
                        // Nova Scotia (NS)
                        new TaxRate { Province = "NS", TaxCategory = "BOOK", Rst = 0.10, Gst = 0.05 },
                        new TaxRate { Province = "NS", TaxCategory = "EBOOK", Rst = 0.10, Gst = 0.05 },
                        new TaxRate { Province = "NS", TaxCategory = "OTHER1", Rst = 0.10, Gst = 0.05 },
                        new TaxRate { Province = "NS", TaxCategory = "OTHER2", Rst = 0.10, Gst = 0.05 },
                        
                        // Nunavut (NU)
                        new TaxRate { Province = "NU", TaxCategory = "BOOK", Rst = 0.0, Gst = 0.05 },
                        new TaxRate { Province = "NU", TaxCategory = "EBOOK", Rst = 0.0, Gst = 0.05 },
                        new TaxRate { Province = "NU", TaxCategory = "OTHER1", Rst = 0.0, Gst = 0.05 },
                        new TaxRate { Province = "NU", TaxCategory = "OTHER2", Rst = 0.0, Gst = 0.05 },
                        
                        // Prince Edward Island (PE)
                        new TaxRate { Province = "PE", TaxCategory = "BOOK", Rst = 0.10, Gst = 0.05 },
                        new TaxRate { Province = "PE", TaxCategory = "EBOOK", Rst = 0.10, Gst = 0.05 },
                        new TaxRate { Province = "PE", TaxCategory = "OTHER1", Rst = 0.10, Gst = 0.05 },
                        new TaxRate { Province = "PE", TaxCategory = "OTHER2", Rst = 0.10, Gst = 0.05 },
                        
                        // Saskatchewan (SK)
                        new TaxRate { Province = "SK", TaxCategory = "BOOK", Rst = 0.06, Gst = 0.05 },
                        new TaxRate { Province = "SK", TaxCategory = "EBOOK", Rst = 0.06, Gst = 0.05 },
                        new TaxRate { Province = "SK", TaxCategory = "OTHER1", Rst = 0.06, Gst = 0.05 },
                        new TaxRate { Province = "SK", TaxCategory = "OTHER2", Rst = 0.06, Gst = 0.05 },
                        
                        // Yukon (YT)
                        new TaxRate { Province = "YT", TaxCategory = "BOOK", Rst = 0.0, Gst = 0.05 },
                        new TaxRate { Province = "YT", TaxCategory = "EBOOK", Rst = 0.0, Gst = 0.05 },
                        new TaxRate { Province = "YT", TaxCategory = "OTHER1", Rst = 0.0, Gst = 0.05 },
                        new TaxRate { Province = "YT", TaxCategory = "OTHER2", Rst = 0.0, Gst = 0.05 }
                    };

                    context.TaxRates.AddRange(taxRates);
                    context.SaveChanges();
                    Console.WriteLine($"Successfully added {taxRates.Length} tax rates.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error initializing tax rates: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Tax rates for all provinces already exist.");
            }
        }

        private static void InitializeProductTaxCategories(ApplicationDbContext context)
        {
            if (!context.ProductTaxCategories.Any())
            {
                Console.WriteLine("Adding product tax categories...");
                
                try
                {
                    var productTaxCategories = new ProductTaxCategory[]
                    {
                        new ProductTaxCategory
                        {
                            BookNumber = 1,
                            TaxCategory = "BOOK",
                            Title = "Sample Book",
                            Isbn = "1234567890"
                        },
                        new ProductTaxCategory
                        {
                            BookNumber = 2,
                            TaxCategory = "EBOOK",
                            Title = "Sample eBook",
                            Isbn = "0987654321"
                        },
                        new ProductTaxCategory
                        {
                            BookNumber = 3,
                            TaxCategory = "OTHER1",
                            Title = "Other Item Type 1",
                            Isbn = "1122334455"
                        },
                        new ProductTaxCategory
                        {
                            BookNumber = 4,
                            TaxCategory = "OTHER2",
                            Title = "Other Item Type 2",
                            Isbn = "5544332211"
                        }
                    };

                    context.ProductTaxCategories.AddRange(productTaxCategories);
                    context.SaveChanges();
                    Console.WriteLine($"Successfully added {productTaxCategories.Length} product tax categories.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error initializing product tax categories: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Product tax categories already exist.");
            }
        }

        private static void InitializeCoupons(ApplicationDbContext context)
        {
            if (!context.BookCoupons.Any())
            {
                Console.WriteLine("Adding sample coupons...");
                
                try
                {
                    var bookCoupons = new BookCoupon[]
                    {
                        new BookCoupon
                        {
                            BookNumber = 1,
                            Value = 10,
                            Usvalue = 7.50m,
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(30),
                            CouponCode = "BOOK10"
                        },
                        new BookCoupon
                        {
                            BookNumber = 2,
                            Value = 5,
                            Usvalue = 3.75m,
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(30),
                            CouponCode = "EBOOK5"
                        }
                    };

                    context.BookCoupons.AddRange(bookCoupons);
                    context.SaveChanges();
                    Console.WriteLine($"Successfully added {bookCoupons.Length} coupons.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error initializing coupons: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Coupons already exist.");
            }
        }
    }
} 