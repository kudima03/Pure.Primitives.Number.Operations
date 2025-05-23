using Pure.Primitives.Abstractions.Number;

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
        Assert.Equal(numbers.Aggregate((x, y) => x * y), new Product<double>(numbers.Select(x => new Double(x))).Value);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyCollection()
    {
        Assert.Throws<InvalidOperationException>(() => new Product<int>(Enumerable.Empty<INumber<int>>()).Value);
    }
}