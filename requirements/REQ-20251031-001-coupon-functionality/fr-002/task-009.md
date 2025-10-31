# Task 009: Add Comprehensive Error Handling

Update all endpoints in `Coupon.API/Program.cs` to handle exceptions and return proper HTTP status codes:
- 400 Bad Request for validation errors
- 404 Not Found for missing coupons
- 409 Conflict for duplicate codes
- 500 Internal Server Error for unexpected errors