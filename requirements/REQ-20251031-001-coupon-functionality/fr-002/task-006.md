# Task 006: Implement POST /coupons Endpoint

In `Coupon.API/Program.cs`, add a minimal API endpoint:
- POST /coupons
- Accept CreateCouponRequest (code, discount, expiration)
- Validate input
- Call CouponService.CreateCouponAsync
- Return 201 Created with coupon ID on success, or appropriate error codes.