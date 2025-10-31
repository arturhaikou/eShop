# REQ-20251031-001:FR-005 — Display Discount on My Orders Page

# Design Considerations

- The My Orders page (or Orders.razor component) MUST retrieve order details including CouponCode and DiscountAmount from Ordering.API.
- Coupon information SHOULD be displayed prominently near the order total for clarity.
- If no coupon is applied, the UI SHOULD either hide the coupon section or display "No coupon applied" label.
- The discount amount display MUST use consistent formatting (e.g., currency format, two decimal places).
- Discount information MUST be read-only (not editable) on historical orders.
- The component SHOULD display discount as a negative amount (e.g., "-$5.00") to clearly indicate a reduction.

# Data Flow

1. Customer navigates to My Orders page.
2. WebApp calls Ordering.API to retrieve customer's orders.
3. Ordering.API returns order list with CouponCode and DiscountAmount included.
4. WebApp component (Orders.razor) binds order data to the view.
5. UI renders coupon code and discount amount if present.

# Affected Components (Projects, Services, Classes)

- `WebApp/Pages/OrdersPage.razor` (or similar) — display order list with coupon details
- `WebApp/Model/OrderDto.cs` (or similar) — DTO includes CouponCode and DiscountAmount
- `Ordering.API/Apis/OrderEndpoints.cs` — GET endpoints return coupon data

# Dependencies

- Order retrieval endpoints from Ordering.API already include CouponCode and DiscountAmount fields
- No new API endpoints required; existing GET order endpoints must return these fields

# Implementation Steps

1. Review Orders.razor and current order display template.
2. Add CouponCode and DiscountAmount to OrderDto/order model used in WebApp.
3. Update order retrieval from Ordering.API to include these fields (likely already included).
4. Add HTML markup to display coupon information: code label, discount amount, total breakdown.
5. Use conditional rendering (@if) to show coupon section only if CouponCode is not null.
6. Apply consistent currency formatting to DiscountAmount display.
7. Test order list display with and without coupons applied.
8. Verify database values match displayed values.
