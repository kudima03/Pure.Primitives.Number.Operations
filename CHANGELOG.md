# Changelog

All notable changes to Pure.Primitives.Number.Operations are documented here.

Format follows [Keep a Changelog](https://keepachangelog.com/en/1.1.0/).

---

## [1.5.0] — 2026-09-08

### Added

- **`IsNonNegativeCondition<T>`** — a new `IBool` condition checking whether a
  value is greater than or equal to `T.Zero`.

## [1.4.0] — 2026-06-17

### Fixed

- **`Product<T>`** now returns the multiplicative identity (`T.One`) for an
  empty input collection, instead of `T.Zero`.

## [1.3.0] — 2025-11-22

### Changed

- Target frameworks expanded from `net9.0` to `net7.0`, `net8.0`, `net9.0`,
  and `net10.0`.

## [1.2.0] — 2025-11-01

### Added

- `NumberValue` is now a public property (previously accessible only through
  the explicit `INumber<T>` implementation) on **`Abs<T>`**,
  **`DecrementedNumber<T>`**, **`Difference<T>`**, **`IncrementedNumber<T>`**,
  **`Max<T>`**, **`Min<T>`**, **`Product<T>`**, **`Quotient<T>`**,
  **`Remainder<T>`**, **`RoundedNumber<T>`**, and **`Sum<T>`**.

## [1.1.0] — 2025-11-01

### Added

- The package now declares NativeAOT compatibility (`IsAotCompatible`).

## [1.0.2] — 2025-06-13

- Maintenance release: dependency and build updates.

## [1.0.1] — 2025-06-07

### Changed

- **Breaking:** `INumber<T>.Value` renamed to `INumber<T>.NumberValue`, and
  `IBool.Value` renamed to `IBool.BoolValue`, across all types
  (`Abs<T>`, `Difference<T>`, `Max<T>`, `Min<T>`, `Product<T>`,
  `Quotient<T>`, `Remainder<T>`, `RoundedNumber<T>`, `Sum<T>`,
  `IncrementedNumber<T>`, `DecrementedNumber<T>`, `EqualCondition<T>`,
  `NotEqualCondition<T>`, `GreaterThanCondition<T>`,
  `GreaterThanOrEqualCondition<T>`, `LessThanCondition<T>`,
  `LessThanOrEqualCondition<T>`), following the updated
  `Pure.Primitives.Abstractions` contract.

## [1.0.0] — 2025-05-27

### Added

- **`IncrementedNumber<T>`** — returns the wrapped number plus one.
- **`DecrementedNumber<T>`** — returns the wrapped number minus one.

### Changed

- Arithmetic now runs in a checked context; overflow/underflow throws
  `OverflowException` instead of wrapping silently.
- `GreaterThanCondition<T>`, `GreaterThanOrEqualCondition<T>`,
  `LessThanCondition<T>`, and `LessThanOrEqualCondition<T>` now accept a
  single-element collection instead of throwing when given fewer than two
  values.
- `Difference<T>`, `Max<T>`, `Min<T>`, `Quotient<T>`, `Remainder<T>`,
  `EqualCondition<T>`, `NotEqualCondition<T>`, `GreaterThanCondition<T>`,
  `GreaterThanOrEqualCondition<T>`, `LessThanCondition<T>`, and
  `LessThanOrEqualCondition<T>` now throw `ArgumentException` (previously
  `InvalidOperationException`) on an empty collection.
- `Sum<T>` and `Product<T>` no longer throw on an empty collection: `Sum<T>`
  returns `0`; `Product<T>` returns `0` (corrected to the multiplicative
  identity `1` in 1.4.0).

## [0.2.1] — 2025-05-26

- Maintenance release: dependency and build updates.

## [0.2.0] — 2025-05-25

### Added

- **`EqualCondition<T>`**, **`NotEqualCondition<T>`** — equality/inequality
  checks across a collection of numbers, returning `IBool`.
- **`GreaterThanCondition<T>`**, **`GreaterThanOrEqualCondition<T>`**,
  **`LessThanCondition<T>`**, **`LessThanOrEqualCondition<T>`** — ordering
  checks across a collection of numbers, returning `IBool`.

### Changed

- Exceptions thrown from `GetHashCode()`/`ToString()` changed from
  `InvalidOperationException` to `NotSupportedException` on `Abs<T>`,
  `Difference<T>`, `Max<T>`, `Min<T>`, `Product<T>`, `Quotient<T>`,
  `Remainder<T>`, `RoundedNumber<T>`, and `Sum<T>`.

## [0.1.0] — 2025-05-23

### Added

- Initial release: numeric primitives implementing `INumber<T>` —
  **`Abs<T>`**, **`Difference<T>`**, **`Max<T>`**, **`Min<T>`**,
  **`Product<T>`**, **`Quotient<T>`**, **`Remainder<T>`**,
  **`RoundedNumber<T>`**, and **`Sum<T>`**.
