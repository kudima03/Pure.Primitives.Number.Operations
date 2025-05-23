﻿using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations.Tests;

public sealed record ProductTests
{
    [Fact]
    public void TakeProduct()
    {
        const int a = 10;
        const int b = 20;
        const int c = 30;

        INumber<int> product = new Product<int>(new Int(a), new Int(b), new Int(c));

        Assert.Equal(a * b * c, product.Value);
    }

    [Fact]
    public void TakeProductFromLargeCollection()
    {
        Random random = new Random();
        IEnumerable<double> numbers = Enumerable.Range(0, 10000).Select(_ => random.NextDouble()).ToArray();
        INumber<double> product = new Product<double>(numbers.Select(x => new Double(x)));
        Assert.Equal(numbers.Aggregate((x, y) => x * y), product.Value);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyCollection()
    {
        INumber<int> product = new Product<int>(Enumerable.Empty<INumber<int>>());
        Assert.Throws<InvalidOperationException>(() => product.Value);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new Product<float>(new Float(10)).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new Product<float>(new Float(10)).ToString());
    }
}