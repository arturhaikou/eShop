# Task 002: Create Database Migration for Order Table

## Goal
Generate and apply an Entity Framework migration to add CouponCode and DiscountAmount columns to the Order table in the database.

## Deliverable
New migration file in `src/Ordering.Infrastructure/Migrations/` that adds the required columns, and updated database schema.

## Dependencies
Task 001 (Order model updated).

## Implementation Notes
- Run `dotnet ef migrations add AddCouponFieldsToOrder` in Ordering.API or Infrastructure project.
- Ensure migration includes nullable string for CouponCode and decimal for DiscountAmount.
- Test migration by running it in development environment.