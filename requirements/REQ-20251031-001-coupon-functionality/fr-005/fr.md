# REQ-20251031-001:FR-005 — Display Discount on My Orders Page

# User Story
As a customer, I want to see the applied coupon discount on the My Orders page so that I can verify the discount was applied and review my purchase history.

# Acceptance Criteria (Given / When / Then)
- Given a customer has placed an order with a coupon discount applied
- When the customer navigates to the My Orders page
- Then each order MUST display the coupon code and discount amount if applicable
- Given an order without a coupon applied
- When the customer views the My Orders page
- Then the discount section SHOULD show "No coupon applied" or be hidden
- Given a customer is reviewing past orders
- When the order list is displayed
- Then coupon information MUST be accurate and match the order record in the database

# Test Outline
1. Place order with coupon, navigate to My Orders, verify coupon code and discount amount are displayed.
2. Place order without coupon, verify "No coupon applied" or empty state is shown.
3. Query database directly and compare displayed discount with stored value.

# Rationale
Transparency in order history builds customer trust and provides a clear audit trail of discounts applied. Customers can verify promotions were honored and reference discount information for support inquiries.

---

## Additional Notes

**Display Elements:**
- Coupon Code (if present)
- Discount Amount (if present)
- New Total reflecting discount
