# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

All `dotnet` commands must be run from the `./src` directory.

```bash
dotnet restore
dotnet build --no-restore -warnaserror /p:RunAnalyzers=true
dotnet format --verify-no-changes             # check code style (CI enforces this)
dotnet format                                 # auto-fix code style
dotnet test --no-build --verbosity normal     # run tests
dotnet pack --configuration Release -p:PackageVersion=<version> --output .
```

## Architecture

This is a **value-object operations library** for the Pure ecosystem. Every file defines exactly one `sealed record` that wraps one or more `INumber<T>` values and exposes the computed result as a new `INumber<T>` or `IBool`.

**Arithmetic types** (implement `INumber<T>`):
- `Sum<T>`, `Difference<T>`, `Product<T>` — aggregations over a sequence of `INumber<T>`
- `Quotient<T>`, `RoundedNumber<T>` — constrained to `IFloatingPoint<T>`
- `Remainder<T>` — sequential modulo over a sequence
- `Abs<T>`, `IncrementedNumber<T>`, `DecrementedNumber<T>` — unary transforms
- `Max<T>`, `Min<T>` — extremes of a sequence

**Comparison types** (implement `IBool` as an explicit interface):
- `EqualCondition<T>`, `NotEqualCondition<T>` — equality across a sequence
- `LessThanCondition<T>`, `LessThanOrEqualCondition<T>` — ascending order checks
- `GreaterThanCondition<T>`, `GreaterThanOrEqualCondition<T>` — descending order checks

All values are **lazy** — computed on every `.NumberValue` / `.BoolValue` access, never cached. `GetHashCode()` and `ToString()` intentionally throw `NotSupportedException`.

**Overflow:** `CheckForOverflowUnderflow=true` — arithmetic that overflows throws `OverflowException`. Tests assert this explicitly.

**Multi-targeting:** net7.0, net8.0, net9.0, net10.0. `IsAotCompatible=true`.

**Tests:** xunit suite under `src/Tests/`, targeting net10.0. CI enforces ≥98% line coverage and ≥99% warning threshold.

**Publishing:** triggered by pushing a semver tag. The tag name becomes the `PackageVersion`. Published to both GitHub Packages and NuGet.

## Code Style

Enforced via `.editorconfig` and `dotnet format --verify-no-changes` in CI:
- No `var` — always use explicit types
- Expression-bodied members only for properties, indexers, and accessors; not for methods or constructors
- File-scoped namespaces (`csharp_style_namespace_declarations = file_scoped`)
- No implicit `new` when type is apparent (`csharp_style_implicit_object_creation_when_type_is_apparent = false`)
- Max line length: 90 characters
- All braces on new lines (`csharp_new_line_before_open_brace = all`)
- Private fields: `_camelCase`; no public non-const, non-static-readonly fields

## Commit Messages

Do not mention Claude or AI assistance in commit messages.
