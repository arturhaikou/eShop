# Task 005: Create Validation Classes

Create validator classes using FluentValidation:
- `CreateCouponRequestValidator` for POST requests, validating code, discount, expiration.
- Ensure code is alphanumeric, discount >0, expiration > now.

Place in `Coupon.API/Validators/` or similar.