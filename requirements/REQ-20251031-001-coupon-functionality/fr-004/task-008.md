# Task 008: Update WebApp Checkout UI to Handle Coupon Validation Errors

## Goal
Modify the checkout page in WebApp to display error messages when coupon validation fails during order placement and allow proceeding with original price.

## Deliverable
Modified `src/WebApp/Components/Pages/Checkout/Checkout.razor` with error message display and logic to handle validation failures from Ordering.API.

## Dependencies
Task 006 and 007.

## Implementation Notes
- Add UI elements to show coupon invalid message.
- Update CheckoutService or page handler to catch errors and display to user.
- Allow user to confirm proceeding without discount or cancel.