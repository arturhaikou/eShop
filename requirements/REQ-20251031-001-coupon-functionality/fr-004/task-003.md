# Task 003: Update OrderService to Handle Coupon Validation and Discount

## Goal
Modify OrderService in Ordering.API to accept coupon code and discount amount, re-validate the coupon with Coupon API, calculate the discounted order total, and handle validation failures.

## Deliverable
Modified `src/Ordering.API/Services/OrderService.cs` with updated CreateOrder method that includes coupon logic, HTTP client for Coupon API, and error handling for invalid coupons.

## Dependencies
Task 001 (Order model), Task 005 (HTTP client registration).

## Implementation Notes
- Add parameters for couponCode and discountAmount to CreateOrder method.
- Call Coupon API to validate coupon before creating order.
- If valid, set fields on Order and calculate OrderTotal = Subtotal - DiscountAmount.
- If invalid, throw exception or return error indicating to proceed without discount or notify user.
- Follow existing service patterns and DI.