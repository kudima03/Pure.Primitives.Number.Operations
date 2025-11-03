using System.Collections.Immutable;
using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Random.Number;

namespace Pure.Primitives.Number.Operations.Tests;

public sealed record DifferenceTests
{
    [Fact]
    public void Subtract()
    {
        IEnumerable<INumber<int>> sample =
        [
            .. new RandomIntCollection(
                new RandomUShort(new UShort(1), new UShort(10000)),
                new Zero<int>(),
                new Int(100000)
            ).Prepend(new MaxInt()),
        ];
        INumber<int> diff = new Difference<int>(sample);
        Assert.Equal(
            sample.Select(x => x.NumberValue).Aggregate((a, b) => a - b),
            diff.NumberValue
        );
    }

    [Fact]
    public void SubtractLargeDoubleCollection()
    {
        IEnumerable<INumber<double>> numbers = new RandomDoubleCollection().ToImmutableArray();
        INumber<double> difference = new Difference<double>();
        Assert.Equal(numbers.Select(x => x.NumberValue).Aggregate((x, y) => x - y), difference.NumberValue);
    }

    [Fact]
    public void HandlesSingleParameter()
    {
        INumber<int> difference = new Difference<int>(new Int(10));
        Assert.Equal(10, difference.NumberValue);
    }

    [Fact]
    public void ThrowsExceptionOnUnderflow()
    {
        INumber<int> valueWithUnderflow = new Difference<int>(new MinInt(), new Int(1));
        _ = Assert.Throws<OverflowException>(() => valueWithUnderflow.NumberValue);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyCollection()
    {
        INumber<int> difference = new Difference<int>([]);
        _ = Assert.Throws<ArgumentException>(() => difference.NumberValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new Difference<float>(new Float(10)).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new Difference<float>(new Float(10)).ToString()
        );
    }
}
