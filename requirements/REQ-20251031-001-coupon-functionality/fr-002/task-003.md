# Task 003: Implement the CouponService Class

Create the `CouponService` class in `Coupon.API/Services/CouponService.cs` with business logic and validation:
- Validate coupon code uniqueness (check if exists and active)
- Validate expiration date (must be in future)
- Validate discount amount (positive and reasonable max)
- Methods: CreateCouponAsync, GetCouponAsync, DeleteCouponAsync

Inject CouponRepository and handle exceptions appropriately.