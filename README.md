# Pure.Primitives.Number.Operations

Composable number operations for the **Pure** ecosystem — arithmetic and comparison value objects over any `INumber<T>`.

[![.NET build & test](https://github.com/kudima03/Pure.Primitives.Number.Operations/actions/workflows/build-and-test.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Primitives.Number.Operations/actions/workflows/build-and-test.yml)
[![Build and Deploy](https://github.com/kudima03/Pure.Primitives.Number.Operations/actions/workflows/publish-nuget.yml/badge.svg?branch=main)](https://github.com/kudima03/Pure.Primitives.Number.Operations/actions/workflows/publish-nuget.yml)
[![NuGet](https://img.shields.io/nuget/v/Pure.Primitives.Number.Operations)](https://www.nuget.org/packages/Pure.Primitives.Number.Operations)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE.txt)

## Overview

`Pure.Primitives.Number.Operations` provides sealed record types that implement arithmetic and comparison operations over [`INumber<T>`](https://github.com/kudima03/Pure.Primitives.Abstractions) values. Each type is a lazy, composable value object — the operation is only evaluated when `.NumberValue` or `.BoolValue` is accessed.

## Operations

### Arithmetic (`INumber<T>`)

| Type | Constraint | Description |
|------|-----------|-------------|
| `Sum<T>` | `INumber<T>` | Sum of one or more numbers |
| `Difference<T>` | `INumber<T>` | Sequential subtraction of a sequence of numbers |
| `Product<T>` | `INumber<T>` | Product of one or more numbers |
| `Quotient<T>` | `IFloatingPoint<T>` | Sequential division of a sequence of numbers |
| `Remainder<T>` | `INumber<T>` | Sequential modulo of a sequence of numbers |
| `Abs<T>` | `INumber<T>` | Absolute value |
| `IncrementedNumber<T>` | `INumber<T>` | Number incremented by one |
| `DecrementedNumber<T>` | `INumber<T>` | Number decremented by one |
| `Max<T>` | `INumber<T>` | Maximum of one or more numbers |
| `Min<T>` | `INumber<T>` | Minimum of one or more numbers |
| `RoundedNumber<T>` | `IFloatingPoint<T>` | Rounded value |

### Comparisons (`IBool`)

| Type | Description |
|------|-------------|
| `EqualCondition<T>` | True when all numbers are equal |
| `NotEqualCondition<T>` | True when at least two numbers differ |
| `LessThanCondition<T>` | True when values are strictly ascending (each < next) |
| `LessThanOrEqualCondition<T>` | True when values are non-decreasing (each ≤ next) |
| `GreaterThanCondition<T>` | True when values are strictly descending (each > next) |
| `GreaterThanOrEqualCondition<T>` | True when values are non-increasing (each ≥ next) |

## Design Principles

- **Lazy** — values are computed on every `.NumberValue` / `.BoolValue` access; no state is cached internally.
- **Composable** — every operation result is itself an `INumber<T>` or `IBool`, so operations nest freely.
- **Overflow-safe** — `CheckForOverflowUnderflow=true`; arithmetic that overflows throws `OverflowException`.
- **AOT-compatible** — `IsAotCompatible=true`; all types work with Native AOT.

## Dependencies

- [`Pure.Primitives.Abstractions`](https://github.com/kudima03/Pure.Primitives.Abstractions/tree/4.3.0) — base primitive interfaces (`INumber<T>`, `IBool`)

## Target Frameworks

- .NET 7
- .NET 8
- .NET 9
- .NET 10

## Installation

```shell
dotnet add package Pure.Primitives.Number.Operations
```

## Usage

```csharp
using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Number.Operations;

// Any INumber<T> implementation works — here using a minimal inline one
sealed class N<T>(T v) : INumber<T> where T : System.Numerics.INumber<T>
{
    public T NumberValue => v;
}

INumber<int> a = new N<int>(10);
INumber<int> b = new N<int>(3);

int sum     = new Sum<int>(a, b).NumberValue;         // 13
int diff    = new Difference<int>(a, b).NumberValue;  // 7
int product = new Product<int>(a, b).NumberValue;     // 30

// Operations compose — abs of (b - a)
int absResult = new Abs<int>(new Difference<int>(b, a)).NumberValue; // 7

// Comparison (IBool is an explicit interface)
bool isGreater = ((IBool)new GreaterThanCondition<int>(a, b)).BoolValue; // true
```
