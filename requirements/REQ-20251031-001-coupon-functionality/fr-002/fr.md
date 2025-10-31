# REQ-20251031-001:FR-002 — Create, Apply, and Delete Coupons API

# User Story
As an administrator, I want to create, retrieve, apply, and delete coupons with fixed discount amounts and expiration dates so that I can manage promotional offers efficiently.

# Acceptance Criteria (Given / When / Then)
- Given a valid coupon code, discount amount, and expiration date are provided
- When an administrator calls the create coupon endpoint
- Then a new coupon record MUST be stored in MongoDB with a unique ID
- Given an existing coupon code
- When an administrator or system calls the delete coupon endpoint
- Then the coupon MUST be removed from MongoDB and MUST no longer be applicable
- Given a valid coupon code is applied to an order
- When the coupon is checked for validity (not expired, exists)
- Then the system MUST retrieve the discount amount MUST make it available for order processing

# Test Outline
1. Create a coupon with a future expiration date and verify it's stored in MongoDB.
2. Attempt to create a coupon with a past expiration date and verify appropriate validation.
3. Delete a coupon and verify it no longer appears in queries.
4. Apply a valid coupon and retrieve its discount amount.

# Rationale
The ability to create and manage coupons programmatically is essential for running promotions and sales. Fixed discount amounts provide simplicity and predictability. Expiration dates ensure promotional offers are time-bound and controlled.

---

## Additional Notes

**Coupon Model Fields:**
- Code (string, unique, alphanumeric)
- DiscountAmount (decimal, fixed fixed-price discount)
- ExpirationDate (DateTime)
- IsActive (boolean, soft delete capability)
- CreatedAt (DateTime)
- UpdatedAt (DateTime)
