# Task 007: Implement GET /coupons/{code} Endpoint

In `Coupon.API/Program.cs`, add a minimal API endpoint:
- GET /coupons/{code}
- Retrieve coupon by code using CouponService
- Return coupon data if active and not expired, else 404 Not Found.