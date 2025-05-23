using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations.Tests;

public sealed record MaxTests
{
    [Fact]
    public void TakeMax()
    {
        const int a = 10;
        const int b = 20;
        const int c = 30;

        INumber<int> max = new Max<int>(new Int(a), new Int(b), new Int(c));

        Assert.Equal(30, max.Value);
    }

    [Fact]
    public void TakeMaxFromSameValues()
    {
        IEnumerable<INumber<int>> numbers = Enumerable.Repeat(new Int(10), 10);

        INumber<int> max = new Max<int>(numbers);

        Assert.Equal(10, max.Value);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyCollection()
    {
        INumber<int> max = new Max<int>(Enumerable.Empty<INumber<int>>());
        Assert.Throws<InvalidOperationException>(() => max.Value);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new Max<float>(new Float(10)).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new Max<float>(new Float(10)).ToString());
    }
}