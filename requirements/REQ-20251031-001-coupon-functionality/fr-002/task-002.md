# Task 002: Create the CouponRepository Class

Implement the `CouponRepository` class in `Coupon.API/Repositories/CouponRepository.cs` with the following methods:
- CreateAsync(Coupon coupon)
- GetByCodeAsync(string code)
- DeleteAsync(string code) // soft delete by setting IsActive to false

Use MongoDB.Driver to interact with the database. Inject IMongoCollection<Coupon> in the constructor.