# Task 008: Implement DELETE /coupons/{code} Endpoint

In `Coupon.API/Program.cs`, add a minimal API endpoint:
- DELETE /coupons/{code}
- Call CouponService.DeleteCouponAsync to soft delete
- Return 204 No Content on success, 404 if not found.