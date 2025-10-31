# Task 001: Update Order Aggregate in Ordering.Domain

## Goal
Add CouponCode (nullable string) and DiscountAmount (decimal, default 0) fields to the Order aggregate in Ordering.Domain to support coupon discounts.

## Deliverable
Modified `src/Ordering.Domain/AggregatesModel/OrderAggregate/Order.cs` with the new fields added to the Order class, following DDD patterns and existing code style.

## Dependencies
None.

## Implementation Notes
- Add properties to the Order class.
- Ensure DiscountAmount is used in total calculation if needed, but primary logic in API layer.
- Follow existing patterns for value objects or simple properties.