using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations.Tests;

public sealed record DifferenceTests
{
    [Fact]
    public void Subtract()
    {
        const int a = 10;
        const int b = 20;
        const int c = 30;
        INumber<int> diff = new Difference<int>(new Int(a), new Int(b), new Int(c));
        Assert.Equal(a - b - c, diff.Value);
    }

    [Fact]
    public void SubtractLargeDoubleCollection()
    {
        Random random = new Random();
        IEnumerable<double> numbers = Enumerable.Range(0, 10000).Select(_ => random.NextDouble()).ToArray();
        INumber<double> difference = new Difference<double>(numbers.Select(x => new Double(x)));
        Assert.Equal(numbers.Aggregate((x, y) => x - y), difference.Value);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyCollection()
    {
        INumber<int> difference = new Difference<int>(Enumerable.Empty<INumber<int>>());
        Assert.Throws<InvalidOperationException>(() => difference.Value);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new Difference<float>(new Float(10)).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new Difference<float>(new Float(10)).ToString());
    }
}