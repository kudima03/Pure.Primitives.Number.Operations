using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations.Tests;

public sealed record LessThanOrEqualConditionTests
{
    [Fact]
    public void TakesPositiveResultOnSameValues()
    {
        IBool condition = new LessThanOrEqualCondition<int>(new Int(10), new Int(10), new Int(10));
        Assert.True(condition.Value);
    }

    [Fact]
    public void TakesPositiveResultOnAscendingValues()
    {
        IBool condition = new LessThanOrEqualCondition<int>(new Int(10), new Int(11), new Int(12));
        Assert.True(condition.Value);
    }

    [Fact]
    public void TakesNegativeResultOnDescendingValues()
    {
        IBool condition = new LessThanOrEqualCondition<int>(new Int(12), new Int(11), new Int(10));
        Assert.False(condition.Value);
    }

    [Fact]
    public void TakesPositiveResultOnAllAscendingOneSameValue()
    {
        IBool condition = new LessThanOrEqualCondition<int>(new Int(11), new Int(12), new Int(13), new Int(13));
        Assert.True(condition.Value);
    }

    [Fact]
    public void TakesNegativeResultOnAllDescendingOneSameValue()
    {
        IBool condition = new LessThanOrEqualCondition<int>(new Int(13), new Int(12), new Int(11), new Int(11));
        Assert.False(condition.Value);
    }

    [Fact]
    public void ThrowsExceptionOnSingleElementInCollection()
    {
        IBool condition = new LessThanOrEqualCondition<int>(new Int(10));
        Assert.Throws<InvalidOperationException>(() => condition.Value);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyCollection()
    {
        IBool condition = new LessThanOrEqualCondition<int>(Enumerable.Empty<INumber<int>>());
        Assert.Throws<InvalidOperationException>(() => condition.Value);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new LessThanOrEqualCondition<float>(new Float(10)).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new LessThanOrEqualCondition<float>(new Float(10)).ToString());
    }
}