# Task 006: Update WebApp CheckoutService to Pass Coupon Data

## Goal
Modify CheckoutService in WebApp to retrieve coupon code and discount amount from BasketState and include them in the order creation request to Ordering.API.

## Deliverable
Modified `src/WebApp/Services/CheckoutService.cs` with updated CreateOrderAsync method to include coupon fields from basket state.

## Dependencies
BasketState updated in FR-003 to include coupon properties.

## Implementation Notes
- Access coupon code and discount from BasketState.
- Add to the order request payload sent to Ordering.API.
- Ensure coupon data is passed correctly in HTTP request.