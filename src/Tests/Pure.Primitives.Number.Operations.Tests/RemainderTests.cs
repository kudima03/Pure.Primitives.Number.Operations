using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations.Tests;

public sealed record RemainderTests
{
    [Fact]
    public void TakesRemainderCorrectly()
    {
        const float a = 10.1F;
        const float b = 20.2F;
        const float c = 30.3F;

        INumber<float> remainder = new Remainder<float>(new Float(a), new Float(b), new Float(c));

        Assert.Equal(a % b % c, remainder.Value);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyCollection()
    {
        INumber<int> remainder = new Remainder<int>(Enumerable.Empty<INumber<int>>());
        Assert.Throws<InvalidOperationException>(() => remainder.Value);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<InvalidOperationException>(() => new Remainder<float>(new Float(10)).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<InvalidOperationException>(() => new Remainder<float>(new Float(10)).ToString());
    }
}