
# 🛒 Fawry Rise Journey – E-Commerce System
## Full Stack Development Internship Challenge

Welcome to my submission for the **Fawry Quantum Internship Challenge**!  
This repository contains a fully functional **e-commerce system** simulation designed using clean object-oriented principles and testable scenarios.

---

## 🚀 Challenge Overview

The goal of this challenge is to design and implement an e-commerce system that supports:

- 🛍️ **Product Definition**:  
  Products have a `name`, `price`, and `quantity`.

- ⏳ **Expiry Handling**:  
  Some items (like Cheese & Biscuits) are expirable, while others (like TVs & Scratch Cards) are not.

- 📦 **Shipping Logic**:  
  Shippable products must provide a `weight`. Others (like mobile scratch cards) do not require shipping.

- 🛒 **Cart Operations**:  
  Customers can add products to their cart with a specific quantity (not exceeding stock).

- 💳 **Checkout Flow**:  
  During checkout, the system:
  - Calculates and prints:
    - Subtotal
    - Shipping fees
    - Total amount paid
    - Customer's remaining balance
  - Throws errors for:
    - Empty cart
    - Expired or out-of-stock items
    - Insufficient customer balance
  - Sends all shippable items to the `ShippingService`, which uses an interface accepting only:
    ```csharp
    string GetName();
    double GetWeight();
    ```

---

## 🧠 Assumptions & Notes

- Interface-based design is used to enforce clean separation and reusability.
- The code includes **multiple test scenarios** for edge cases and expected flows.
- Code is written in **C#**, showcasing object-oriented structure, exception handling, and separation of concerns.

---

## ✅ Example Console Output

```text
** Shipment notice **
2x Cheese 400g
1x Biscuits 700g
Total package weight 1.1kg

** Checkout receipt **
2x Cheese 200
1x Biscuits 150
----------------------
Subtotal 350
Shipping 30
Amount 380
