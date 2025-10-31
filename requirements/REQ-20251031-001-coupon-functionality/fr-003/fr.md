# REQ-20251031-001:FR-003 — Coupon Form in Shopping Cart UI

# User Story
As a customer, I want to enter a coupon code in the shopping cart below the total so that I can apply promotional discounts to my purchase.

# Acceptance Criteria (Given / When / Then)
- Given the customer is viewing the shopping cart with items and total price
- When the customer enters a valid coupon code and clicks the Apply button
- Then the coupon discount MUST be applied and the new total MUST be displayed
- Given the customer enters an invalid or expired coupon code
- When the customer clicks the Apply button
- Then an error message MUST be displayed informing the user the coupon is invalid or expired
- Given a coupon is successfully applied
- When the customer clicks Remove button next to the coupon
- Then the coupon MUST be removed and the total MUST revert to the original price

# Test Outline
1. Add items to cart, enter valid coupon code, click Apply, verify discount is applied and total updates.
2. Enter invalid coupon code, click Apply, verify error message appears.
3. Apply valid coupon, click Remove, verify coupon is removed and total reverts.

# Rationale
Providing a coupon input field in the shopping cart improves user experience and encourages customers to use promotional offers, thereby increasing conversion rates and order values.

---

## Additional Notes

**UI Location:** Below the shopping cart total  
**Form Elements:** Text input for coupon code, Apply button, Remove button, discount display  
**Validation:** Client-side format validation + server-side API validation
