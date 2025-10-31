# REQ-20251031-001:FR-004 — Order Placement with Coupon Discount

# Design Considerations

- The Ordering.API MUST accept coupon code and discount amount from WebApp during order creation.
- Ordering.API SHOULD re-validate the coupon with Coupon API before finalizing the order (to prevent expired or deleted coupons).
- If coupon validation fails at order time, the system SHOULD notify the customer and either proceed without discount or fail the order gracefully.
- Order entity MUST include CouponCode and DiscountAmount fields for record-keeping.
- The order total calculation MUST deduct DiscountAmount from the subtotal to produce the final OrderTotal.
- Audit logging SHOULD capture coupon usage for reconciliation and reporting.

# Data Flow

1. Customer applies coupon in cart and proceeds to checkout.
2. WebApp sends order request to Ordering.API with coupon code and discount amount.
3. Ordering.API calls Coupon API to re-validate the coupon.
4. If valid, Ordering.API creates order with CouponCode and DiscountAmount fields populated.
5. Order total is calculated as: (Subtotal - DiscountAmount) = OrderTotal.
6. Order is persisted to database with coupon reference.
7. If coupon is invalid/expired, API returns error and requests customer action.

# Affected Components (Projects, Services, Classes)

- `Ordering.API/Model/Order.cs` — add CouponCode and DiscountAmount fields
- `Ordering.API/Services/OrderService.cs` — logic for coupon validation and order creation
- `Ordering.API/Apis/OrderEndpoints.cs` — POST endpoint accepts coupon data
- `WebApp/Services/CheckoutService.cs` (or similar) — passes coupon to Ordering.API

# Dependencies

- HTTP client for Coupon API communication from Ordering.API
- Order entity database schema update (migration)

# Implementation Steps

1. Add CouponCode (string, nullable) and DiscountAmount (decimal) fields to Order model.
2. Create database migration to add these fields to Order table.
3. Update OrderService to accept coupon code and discount amount parameters.
4. Implement coupon re-validation in OrderService before order creation.
5. Update order creation logic to calculate final OrderTotal with discount deduction.
6. Update POST /orders endpoint to accept coupon data in request body.
7. Update WebApp checkout flow to pass coupon code and discount to Ordering.API.
8. Add error handling for coupon validation failures (expired, not found, etc.).
9. Test order creation with and without coupons.
10. Verify database records include coupon information.
