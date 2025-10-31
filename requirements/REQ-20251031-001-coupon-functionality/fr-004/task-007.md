# Task 007: Add Error Handling for Coupon Validation Failures in Ordering.API

## Goal
Implement error handling in Ordering.API for cases where coupon validation fails, returning appropriate responses to indicate price changes or invalid coupons.

## Deliverable
Modified `src/Ordering.API/Services/OrderService.cs` and `Apis/OrderEndpoints.cs` with try-catch blocks and custom exceptions or status codes for coupon errors.

## Dependencies
Task 003 and 004.

## Implementation Notes
- Catch validation errors from Coupon API call.
- Return HTTP 400 or custom error response indicating coupon invalid, with option to proceed without discount.
- Log errors appropriately.