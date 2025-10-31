# Task 004: Update Order Endpoints to Accept Coupon Data

## Goal
Modify the POST /orders endpoint in Ordering.API to accept coupon code and discount amount in the request body and pass them to OrderService.

## Deliverable
Modified `src/Ordering.API/Apis/OrderEndpoints.cs` with updated request model and endpoint handler to include coupon fields.

## Dependencies
Task 003 (OrderService updated).

## Implementation Notes
- Add CouponCode and DiscountAmount to the order creation request DTO.
- Update the POST endpoint to extract and pass these values to OrderService.CreateOrder.
- Ensure request validation for coupon fields.