using System.Collections.Immutable;
using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Random.Number;

namespace Pure.Primitives.Number.Operations.Tests;

public sealed record DifferenceTests
{
    [Fact]
    public void Subtract()
    {
        IEnumerable<INumber<int>> sample = new RandomIntCollection().ToImmutableArray();
        INumber<int> diff = new Difference<int>(sample);
        Assert.Equal(sample.Select(x => x.NumberValue).Aggregate((a, b) => a - b), diff.NumberValue);
    }

    [Fact]
    public void SubtractLargeDoubleCollection()
    {
        Random random = new Random();
        IEnumerable<double> numbers =
        [
            .. Enumerable.Range(0, 10000).Select(_ => random.NextDouble()),
        ];
        INumber<double> difference = new Difference<double>(
            numbers.Select(x => new Double(x))
        );
        Assert.Equal(numbers.Aggregate((x, y) => x - y), difference.NumberValue);
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
