# REQ-20251031-001:FR-003 — Coupon Form in Shopping Cart UI

# Design Considerations

- The coupon form SHOULD be integrated into the CartPage.razor component (or similar cart UI).
- The form MUST include a text input field for coupon code entry with placeholder text (e.g., "Enter coupon code").
- The form MUST include an Apply button that calls the Coupon API to validate and apply the coupon.
- A Remove button SHOULD be displayed once a coupon is applied, allowing removal.
- Discount amount SHOULD be clearly displayed below or next to the total (e.g., "Coupon Discount: -$5.00").
- New total (original price minus discount) MUST be displayed and update reactively.
- Error messages MUST be user-friendly and explain why a coupon was rejected (expired, not found, etc.).
- Loading state SHOULD be shown while API validation is in progress.
- The component SHOULD disable the Apply button while a request is pending.

# Data Flow

1. Customer enters coupon code in text input and clicks Apply.
2. WebApp calls Coupon API with coupon code.
3. Coupon API validates (exists, not expired) and returns discount amount or error.
4. WebApp updates cart state with discount or displays error message.
5. UI reactively updates total and displays discount information.
6. Customer can click Remove to clear the coupon.

# Affected Components (Projects, Services, Classes)

- `WebApp/Pages/CartPage.razor` — UI form and handler
- `WebApp/Services/CouponService.cs` (or HTTP client wrapper) — calls Coupon API
- `WebApp/Model/CartState.cs` (or similar) — tracks applied coupon and discount

# Dependencies

- Coupon API HTTP client (must be registered in WebApp DI container)
- Razor component form handling (e.g., EditForm, @onsubmit)
- HTTP client for calling Coupon API endpoints

# Implementation Steps

1. Review CartPage.razor and understand current total calculation.
2. Create a new CouponService in WebApp to call Coupon API endpoints.
3. Add coupon form markup to CartPage.razor below the total (text input + Apply button).
4. Implement handler method to call CouponService.ValidateCoupon() on Apply button click.
5. Update cart state/properties to store applied coupon code and discount amount.
6. Bind form fields using @bind-Value and EditForm or form element with @formname.
7. Display discount amount and new total reactively.
8. Add Remove button handler to clear coupon and reset total.
9. Add error message display with user-friendly messaging.
10. Test form submission, validation responses, and UI updates.
