# Task 001: Define the Coupon Model

Create the `Coupon` class in `Coupon.API/Model/Coupon.cs` with the following properties:
- Id (string or ObjectId for MongoDB)
- Code (string, unique, case-insensitive)
- DiscountAmount (decimal)
- ExpirationDate (DateTime, UTC)
- IsActive (bool)
- CreatedAt (DateTime)
- UpdatedAt (DateTime)

Ensure the class is properly annotated for MongoDB serialization if needed.