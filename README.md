# CaptusCatalog - Tax Calculation Service

This service handles tax calculations for the CaptusCatalog application, supporting various tax rates based on product category, province, and country.

## Features

- **Dynamic Tax Lookup**: Maps book numbers to tax categories and retrieves appropriate tax rates
- **Mixed Cart Calculations**: Support for calculating taxes on carts with different product types
- **Multiple Tax Categories**: Supports different tax categories (BOOK, EBOOK, etc.)
- **Coupon Support**: Applies coupons to reduce taxable base before tax calculation
- **Tax Exemptions**: Handles tax exemptions for non-Canada orders
- **Error Handling**: Comprehensive error handling with clear error messages

## API Endpoints

### Calculate Tax for Single Item

```
GET /api/TaxCalculation/calculate?bookNumber=1&province=ON&price=100
```

### Calculate Tax for Cart

```
POST /api/TaxCalculation/calculate-cart
Content-Type: application/json

{
  "items": [
    {
      "itemId": "item1",
      "bookNumber": 1,
      "price": 100.00,
      "couponAmount": 10.00
    },
    {
      "itemId": "item2",
      "bookNumber": 2,
      "price": 50.00
    }
  ],
  "province": "ON",
  "country": "CA"
}
```

### Get Coupon Amount

```
GET /api/TaxCalculation/coupon?bookNumber=1&couponCode=BOOK10
```

## Examples

### Example 1: Calculate Tax for Book in Ontario

For a book (TaxCategory = "BOOK") in Ontario (Province = "ON"), with a price of $100:
- GST = 5% = $5.00
- RST = 8% = $8.00
- Total tax = $13.00
- Final price = $113.00

### Example 2: Apply 10% Coupon on $100 Book

For a book with a price of $100 and a 10% ($10) coupon:
- Discounted price = $90.00
- GST = 5% of $90 = $4.50
- RST = 8% of $90 = $7.20
- Total tax = $11.70
- Final price = $101.70

### Example 3: Mixed Cart with Different Tax Categories

A cart with a $100 BOOK and a $100 EBOOK in Ontario:
- Both have same tax rates in Ontario (GST 5% + RST 8%)
- Total before tax = $200
- Total tax = $26.00
- Grand total = $226.00

### Example 4: Non-Canada Order

For a US order (country = "US"):
- No tax is applied
- Final price = original price 