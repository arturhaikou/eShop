# REQ-20251031-001:FR-004 — Order Placement with Coupon Discount

# User Story
As a customer, I want orders to be placed with the adjusted price based on the applied coupon discount so that I pay the correct amount after promotion.

# Acceptance Criteria (Given / When / Then)
- Given a valid coupon is applied in the shopping cart
- When the customer proceeds to checkout and places an order
- Then the order MUST be created with the discounted total price
- Given an order is placed with a coupon applied
- When the order record is stored
- Then the order MUST include the coupon code and discount amount for reference
- Given an order is placed but the coupon has expired between application and checkout
- When the system validates the coupon at order time
- Then the system SHOULD proceed with the original price or notify the customer of the price change

# Test Outline
1. Apply valid coupon in cart ($5 discount), proceed to checkout, place order, verify order total reflects discount.
2. Verify order record includes coupon code and discount amount in database.
3. Simulate coupon expiration between cart and checkout, verify system handles gracefully.

# Rationale
Accurate order pricing with applied discounts is critical for customer trust, accounting, and fulfillment operations. Storing coupon details ensures audit trail and dispute resolution capabilities.

---

## Additional Notes

**Order Model Enhancement:**
- Add CouponCode field (nullable string)
- Add DiscountAmount field (decimal, default 0)
- OrderTotal MUST reflect DiscountAmount deduction
