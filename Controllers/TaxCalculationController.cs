using CaptusCatalog.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Collections.Generic;

namespace CaptusCatalog.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaxCalculationController : ControllerBase
    {
        private readonly TaxCalculationService _taxService;
        private readonly ILogger<TaxCalculationController> _logger;

        public TaxCalculationController(TaxCalculationService taxService, ILogger<TaxCalculationController> logger)
        {
            _taxService = taxService;
            _logger = logger;
        }

        [HttpGet("calculate")]
        public ActionResult CalculateTax(
            [FromQuery] int bookNumber,
            [FromQuery] string province,
            [FromQuery] decimal price,
            [FromQuery] decimal? couponAmount = null,
            [FromQuery] string country = "CA")
        {
            try
            {
                var result = _taxService.GetTax(bookNumber, province, price, couponAmount, country);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Invalid input for tax calculation");
                return BadRequest(new { error = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Tax data not found");
                return NotFound(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calculating tax");
                return StatusCode(500, new { error = "An unexpected error occurred" });
            }
        }

        [HttpPost("calculate-cart")]
        public ActionResult CalculateCartTax(
            [FromBody] CartTaxRequest request)
        {
            try
            {
                if (request?.Items == null || !request.Items.Any())
                {
                    return BadRequest(new { error = "No items provided" });
                }

                _logger.LogInformation("Calculating tax for cart with {ItemCount} items in province {Province}", 
                    request.Items.Count, request.Province);

                var results = _taxService.CalculateMixedCartTaxes(request.Items, request.Province, request.Country);
                
                // Calculate summary
                decimal totalBeforeTax = request.Items.Sum(i => i.Price);
                decimal totalDiscounted = results.Sum(r => r.DiscountedAmount);
                decimal totalGst = results.Sum(r => r.GstAmount);
                decimal totalRst = results.Sum(r => r.RstAmount);
                decimal totalTax = results.Sum(r => r.TotalTaxAmount);
                decimal grandTotal = results.Sum(r => r.TotalAmount);

                return Ok(new
                {
                    Items = results,
                    Summary = new
                    {
                        TotalBeforeTax = totalBeforeTax,
                        TotalDiscounted = totalDiscounted,
                        TotalGst = totalGst,
                        TotalRst = totalRst,
                        TotalTax = totalTax,
                        GrandTotal = grandTotal
                    }
                });
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Tax data not found: {Message}", ex.Message);
                return NotFound(new { error = ex.Message });
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Invalid input for tax calculation: {Message}", ex.Message);
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calculating cart tax: {Message}", ex.Message);
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet("coupon")]
        public ActionResult GetCoupon(int bookNumber, string couponCode)
        {
            try
            {
                _logger.LogInformation("Retrieving coupon for book {BookNumber} with code {CouponCode}", bookNumber, couponCode);
                
                var couponAmount = _taxService.GetCouponAmount(bookNumber, couponCode);
                
                if (couponAmount.HasValue)
                {
                    return Ok(new { amount = couponAmount.Value });
                }
                
                return NotFound(new { message = "Coupon not found or not valid for this book" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving coupon: {Message}", ex.Message);
                return StatusCode(500, new { error = $"An error occurred: {ex.Message}" });
            }
        }
    }

    public class CartTaxRequest
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public string Province { get; set; } = string.Empty;
        public string Country { get; set; } = "CA";
    }
} 