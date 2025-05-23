using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations.Tests;

public sealed record DifferenceTests
{
    [Fact]
    public void SubtractCorrectly()
    {
        const int a = 10;
        const int b = 20;
        const int c = 30;
        INumber<int> diff = new Difference<int>(new Int(a), new Int(b), new Int(c));
        Assert.Equal(a - b - c, diff.Value);
    }

    [Fact]
    public void SubtractLargeDoubleCollectionCorrectly()
    {
        Random random = new Random();
        IEnumerable<double> numbers = Enumerable.Range(0, 10000).Select(_ => random.NextDouble()).ToArray();
        Assert.Equal(numbers.Aggregate((x, y) => x - y),
            new Difference<double>(numbers.Select(x => new Double(x))).Value);
    }

    [Fact]
    public void SubtractEmptyCollectionCorrectly()
    {
        Assert.Equal(0, new Difference<int>(Enumerable.Empty<INumber<int>>()).Value);
    }
}