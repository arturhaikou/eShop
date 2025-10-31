# REQ-20251031-001:FR-006 — Coupon Validation in Web Project

# Design Considerations

- **Client-side validation** MUST use Blazor/HTML5 validation attributes or JavaScript to validate coupon code format:
  - Alphanumeric characters only (letters and numbers).
  - Length between 3 and 20 characters.
  - No spaces or special characters.
- **Server-side validation** in Coupon API MUST check:
  - Coupon code exists in database and IsActive is true.
  - Expiration date is in the future (not expired).
  - Discount amount is valid.
- **State management** in WebApp MUST ensure only one coupon is stored in the cart state at a time.
- Validation errors MUST be caught and transformed into user-friendly messages.
- **API error handling** in WebApp MUST differentiate between validation errors (400), not found (404), and server errors (500).

# Data Flow

1. User enters coupon code and clicks Apply button.
2. Client-side validation checks format and length.
3. If format invalid, error displayed immediately; no API call made.
4. If format valid, WebApp calls Coupon API: GET /coupons/{code}.
5. Coupon API retrieves coupon from MongoDB and validates expiration.
6. If valid, API returns DiscountAmount and 200 OK.
7. If invalid/expired/not found, API returns error (400/404) with reason.
8. WebApp receives response, updates cart state with coupon or displays error.
9. UI displays error message or applies discount based on response.

# Affected Components (Projects, Services, Classes)

- `WebApp/Components/CouponForm.razor` (or part of CartPage.razor) — form markup and handlers
- `WebApp/Services/CouponClientService.cs` — HTTP client wrapper for Coupon API calls
- `WebApp/Model/CartState.cs` (or similar) — tracks applied coupon
- `Coupon.API/Services/CouponService.cs` — server-side validation logic

# Dependencies

- Blazor EditForm and validation components (built-in).
- Data Annotations for validation attributes.
- HTTP client for Coupon API communication.
- FluentValidation (optional, for more complex client validation).

# Implementation Steps

1. Create CouponForm.razor component with text input for coupon code and Apply/Remove buttons.
2. Add HTML5 validation attributes: pattern (alphanumeric), minlength="3", maxlength="20".
3. Implement client-side validation using Blazor's EditForm or custom JavaScript.
4. Create CouponClientService class to wrap HTTP calls to Coupon API.
5. Implement CouponService.ValidateCoupon(code) method that calls GET /coupons/{code}.
6. In CartPage handler, call CouponClientService, handle responses (success/error).
7. Update CartState to store only one active coupon at a time.
8. Display error messages based on API response status codes.
9. Show loading state while API validation is in progress.
10. Test with valid, invalid, expired, and non-existent coupon codes.
