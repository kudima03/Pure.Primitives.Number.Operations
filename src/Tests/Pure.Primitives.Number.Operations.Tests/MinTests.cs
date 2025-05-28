using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations.Tests;

public sealed record MinTests
{
    [Fact]
    public void TakeMin()
    {
        const int a = 10;
        const int b = 20;
        const int c = 30;

        INumber<int> min = new Min<int>(new Int(a), new Int(b), new Int(c));

        Assert.Equal(10, min.NumberValue);
    }

    [Fact]
    public void TakeMinFromSameValues()
    {
        IEnumerable<INumber<int>> numbers = Enumerable.Repeat(new Int(10), 10);

        INumber<int> min = new Min<int>(numbers);

        Assert.Equal(10, min.NumberValue);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyCollection()
    {
        INumber<int> min = new Min<int>(Enumerable.Empty<INumber<int>>());
        Assert.Throws<ArgumentException>(() => min.NumberValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new Min<float>(new Float(10)).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new Min<float>(new Float(10)).ToString());
    }
}