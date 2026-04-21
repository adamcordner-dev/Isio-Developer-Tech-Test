# Gilded Rose Refactoring Exercise

## Overview

This project is a refactored version of the classic Gilded Rose kata. The original implementation consisted of a single method containing deeply nested conditional logic, which made it difficult to maintain, extend, and reason about.

The goal of this refactor was to improve readability, maintainability, and extensibility while keeping all existing behaviour intact and introducing an additional feature to demonstrate flexibility of the design.

---

## Approach

Coming into this, I wanted to focus on improving the structure of the existing logic without over-engineering the solution. The original `UpdateQuality` method contained multiple branching conditions tied to item names, which made it fragile and difficult to extend safely.

To address this, I applied the **Strategy Pattern**, which I’m familiar with from previous work where we’ve used it to isolate varying business rules behind a common interface.

---

## Key Refactoring Decisions

### 1. Strategy Pattern for Item Behaviour

Each item type now has its own dedicated implementation of `IItemUpdater`, responsible for handling its own update logic.

This removes the need for large conditional blocks and makes each behaviour:
- Easier to understand
- Easier to test
- Safe to extend without affecting existing logic

Example implementations:
- `NormalItemUpdater`
- `AgedBrieUpdater`
- `BackstagePassesUpdater`
- `ConjuredItemUpdater`
- `SulfurasUpdater`
- `LuxuryItemUpdater`

---

### 2. Factory for Resolution

An `ItemUpdaterFactory` is used to resolve the correct updater based on the item name.

Due to the constraint that the `Item` class could not be modified, string-based matching was used as a practical solution.

In a real-world system, I would prefer a more strongly typed approach (e.g. enum or dedicated item model) to avoid reliance on string matching.

---

### 3. Shared Quality Logic

A `QualityHelper` was introduced to centralise logic around quality constraints:

- Quality never exceeds the maximum limit
- Quality never drops below zero

This avoids duplication across updater classes and ensures consistency of business rules.

---

### 4. Separation of Concerns

The original `Program.cs` was responsible for both data setup and execution logic.

While this was left intact for the purposes of the kata, in a production system I would move item creation and initialisation into a separate service or data layer to keep the entry point focused purely on orchestration.

---

## Testing Strategy

The solution is fully covered with unit tests, including:

- Individual updater behaviour tests
- Factory resolution tests
- End-to-end system tests via `GildedRose`
- Edge cases such as quality boundaries (0 and max limits)

This ensures confidence that refactoring has not changed expected behaviour.

---

## Extension Beyond Requirements

To demonstrate extensibility, I added a new item type:

### Luxury Items
Luxury items degrade in a controlled manner with a defined minimum quality threshold. This demonstrates how new business rules can be introduced without modifying existing logic.

---

## Additional Extension Ideas

If this system were to evolve further, there are a few directions I would consider:

- **Perishable / Shelf-Stable Items**
  Items that degrade at different rates based on time intervals (e.g. every 2 days rather than daily). This was intentionally not implemented to avoid overcomplicating the solution but would fit naturally into the current structure.

- **Rule-driven item configuration**
  Instead of relying on string matching, item behaviour could be driven by configuration or metadata, removing the need for factory branching logic entirely.

---

## Trade-offs

- String matching was used due to the constraint of not modifying the `Item` class
- A factory pattern introduces a small amount of abstraction overhead but significantly improves maintainability and clarity
- Some logic (such as item initialisation in `Program.cs`) could be further separated in a production-grade architecture

---

## Summary

Overall, this refactor focuses on:

- Improving readability by removing nested conditionals
- Increasing maintainability through separation of concerns
- Making behaviour easy to extend via the Strategy Pattern
- Improving testability by isolating business rules

The result is a codebase that is significantly easier to reason about and extend while preserving all original functionality.
