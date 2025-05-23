using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations.Tests;

public sealed record MinTests
{
    [Fact]
    public void ComputeMinCorrectly()
    {
        const int a = 10;
        const int b = 20;
        const int c = 30;

        INumber<int> max = new Min<int>(new Int(a), new Int(b), new Int(c));

        Assert.Equal(10, max.Value);
    }

    [Fact]
    public void ComputeMinCorrectlyFromSameValues()
    {
        IEnumerable<INumber<int>> numbers = Enumerable.Repeat(new Int(10), 10);

        INumber<int> max = new Min<int>(numbers);

        Assert.Equal(10, max.Value);
    }

    [Fact]
    public void ComputeMinCorrectlyFromEmptyCollection()
    {
        Assert.Throws<InvalidOperationException>(() => new Min<int>(Enumerable.Empty<INumber<int>>()).Value);
    }
}