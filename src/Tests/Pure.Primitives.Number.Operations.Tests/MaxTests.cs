using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations.Tests;

public sealed record MaxTests
{
    [Fact]
    public void ComputeMaxCorrectly()
    {
        const int a = 10;
        const int b = 20;
        const int c = 30;

        INumber<int> max = new Max<int>(new Int(a), new Int(b), new Int(c));

        Assert.Equal(30, max.Value);
    }

    [Fact]
    public void ComputeMaxCorrectlyFromSameValues()
    {
        IEnumerable<INumber<int>> numbers = Enumerable.Repeat(new Int(10), 10);

        INumber<int> max = new Max<int>(numbers);

        Assert.Equal(10, max.Value);
    }

    [Fact]
    public void ComputeMaxCorrectlyFromEmptyCollection()
    {
        Assert.Throws<InvalidOperationException>(() => new Max<int>(Enumerable.Empty<INumber<int>>()).Value);
    }
}