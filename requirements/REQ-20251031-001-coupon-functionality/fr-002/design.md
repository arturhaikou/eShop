# REQ-20251031-001:FR-002 — Create, Apply, and Delete Coupons API

# Design Considerations

- Coupon codes MUST be unique and case-insensitive for user convenience.
- Discount amounts MUST be positive decimal values (e.g., 5.00 for $5 discount).
- Expiration dates MUST be stored as UTC DateTime to ensure consistency across time zones.
- Soft deletion (IsActive flag) SHOULD be used instead of hard deletion for audit and reporting purposes.
- The API SHOULD validate that discount amounts are reasonable (e.g., not exceeding maximum allowable discount).
- Duplicate coupon code creation MUST be prevented with appropriate error response (409 Conflict).
- Coupon retrieval endpoints SHOULD filter by IsActive status by default.

# Data Flow

1. Administrator submits coupon creation request with code, discount, and expiration date.
2. Coupon API validates input and checks for duplicates.
3. New coupon record is persisted to MongoDB.
4. API returns coupon ID and confirmation.
5. On apply request, API retrieves coupon by code and checks expiration date.
6. On delete request, API marks coupon as inactive (soft delete).

# Affected Components (Projects, Services, Classes)

- `Coupon.API` — CRUD endpoints and business logic
- `Coupon.API/Model/Coupon.cs` — coupon entity
- `Coupon.API/Repositories/CouponRepository.cs` — MongoDB data access
- `Coupon.API/Services/CouponService.cs` — business logic and validation

# Dependencies

- MongoDB C# Driver
- DateTimeOffset or DateTime utilities for UTC handling
- Input validation libraries (FluentValidation or Data Annotations)

# Implementation Steps

1. Define Coupon model with properties: Id, Code, DiscountAmount, ExpirationDate, IsActive, CreatedAt, UpdatedAt.
2. Create CouponRepository with CRUD methods and MongoDB operations.
3. Implement CouponService with validation logic (expiration, uniqueness, discount bounds).
4. Create API endpoints: POST /coupons (create), GET /coupons/{code} (retrieve), DELETE /coupons/{code} (soft delete).
5. Add input validation using FluentValidation or Data Annotations.
6. Implement error handling (409 for duplicates, 404 for not found, 400 for validation errors).
7. Test all CRUD operations locally with MongoDB.
