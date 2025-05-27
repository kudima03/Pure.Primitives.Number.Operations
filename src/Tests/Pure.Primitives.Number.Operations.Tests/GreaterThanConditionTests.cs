using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations.Tests;

public sealed record GreaterThanConditionTests
{
    [Fact]
    public void TakesNegativeResultOnSameValues()
    {
        IBool isGreaterThan = new GreaterThanCondition<int>(new Int(10), new Int(10), new Int(10));
        Assert.False(isGreaterThan.Value);
    }

    [Fact]
    public void TakesNegativeResultOnAscendingValues()
    {
        IBool isGreaterThan = new GreaterThanCondition<int>(new Int(10), new Int(11), new Int(12));
        Assert.False(isGreaterThan.Value);
    }

    [Fact]
    public void TakesPositiveResultOnDescendingValues()
    {
        IBool isGreaterThan = new GreaterThanCondition<int>(new Int(12), new Int(11), new Int(10));
        Assert.True(isGreaterThan.Value);
    }

    [Fact]
    public void TakesNegativeResultOnAllAscendingOneSameValue()
    {
        IBool isGreaterThan = new GreaterThanCondition<int>(new Int(11), new Int(12), new Int(13), new Int(13));
        Assert.False(isGreaterThan.Value);
    }

    [Fact]
    public void TakesPositiveResultOnSingleElementInCollection()
    {
        IBool isGreaterThan = new GreaterThanCondition<int>(new Int(10));
        Assert.True(isGreaterThan.Value);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyCollection()
    {
        IBool isGreaterThan = new GreaterThanCondition<int>(Enumerable.Empty<INumber<int>>());
        Assert.Throws<ArgumentException>(() => isGreaterThan.Value);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new GreaterThanCondition<float>(new Float(10)).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new GreaterThanCondition<float>(new Float(10)).ToString());
    }
}