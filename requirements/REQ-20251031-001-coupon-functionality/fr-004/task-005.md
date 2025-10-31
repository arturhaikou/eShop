# Task 005: Register HTTP Client for Coupon API in Ordering.API

## Goal
Add HTTP client registration for Coupon API in Ordering.API to enable communication for coupon validation.

## Deliverable
Modified `src/Ordering.API/Program.cs` or `Extensions/` with added HttpClient for Coupon API, following Aspire patterns.

## Dependencies
Coupon API project available (from FR-003).

## Implementation Notes
- Use AddHttpClient to register a typed or named client for Coupon API.
- Configure base address from appsettings.
- Add to Aspire distributed application builder if needed.