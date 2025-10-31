# REQ-20251031-001:FR-006 — Coupon Validation in Web Project

# User Story
As a system, I want to validate coupon codes in the web project so that invalid coupons are rejected before reaching the backend and users receive immediate feedback.

# Acceptance Criteria (Given / When / Then)
- Given a user enters a coupon code in the shopping cart
- When the user clicks Apply
- Then the WebApp MUST validate the coupon code format (alphanumeric, length constraints)
- Given a coupon code passes format validation
- When the WebApp calls the Coupon API
- Then the API MUST validate expiration date and existence, returning discount amount or error
- Given the Coupon API returns an error
- When the WebApp receives the response
- Then an appropriate error message MUST be displayed to the user and the coupon MUST NOT be applied
- Given a coupon passes all validation
- When the discount is applied to the cart
- Then the system MUST prevent application of additional coupons (only one per order)

# Test Outline
1. Enter invalid coupon code format, verify client-side validation error.
2. Enter valid format but non-existent coupon, verify API error is caught and displayed.
3. Enter valid coupon, verify it applies successfully and a second coupon application is blocked.

# Rationale
Client-side validation provides immediate feedback and reduces unnecessary API calls. Server-side validation in the Coupon API ensures security and business rule enforcement. Together, they create a robust validation pipeline that improves UX and prevents abuse.

---

## Additional Notes

**Validation Rules:**
- Client-side: Code format (alphanumeric, 3-20 characters, no spaces)
- Server-side: Existence in database, expiration date check, IsActive status
- One coupon per order enforcement at application time
