﻿using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations.Tests;
public sealed record SumTests
{
    [Fact]
    public void TakesSum()
    {
        const int a = 10;
        const int b = 20;
        const int c = 30;
        INumber<int> sum = new Sum<int>(new Int(a), new Int(b), new Int(c));
        Assert.Equal(a + b + c, sum.NumberValue);
    }

    [Fact]
    public void TakesSumFromLargeDoubleCollection()
    {
        Random random = new Random();
        IEnumerable<double> numbers = Enumerable.Range(0, 10000).Select(_ => random.NextDouble()).ToArray();
        INumber<double> sum = new Sum<double>(numbers.Select(x => new Double(x)));
        Assert.Equal(numbers.Sum(), sum.NumberValue);
    }

    [Fact]
    public void TakesSumFromSingleParameter()
    {
        INumber<int> sum = new Sum<int>(new Int(10));
        Assert.Equal(10, sum.NumberValue);
    }

    [Fact]
    public void TakesSumFromEmptyCollection()
    {
        INumber<int> sum = new Sum<int>(Enumerable.Empty<INumber<int>>());
        Assert.Equal(0, sum.NumberValue);
    }

    [Fact]
    public void ThrowsExceptionOnOverflow()
    {
        INumber<int> valueWithOverflow = new Sum<int>(new MaxInt(), new Int(1));
        Assert.Throws<OverflowException>(() => valueWithOverflow.NumberValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new Sum<float>(new Float(10)).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new Sum<float>(new Float(10)).ToString());
    }
}