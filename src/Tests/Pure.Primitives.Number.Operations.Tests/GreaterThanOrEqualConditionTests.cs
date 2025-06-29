﻿using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations.Tests;

public sealed record GreaterThanOrEqualConditionTests
{
    [Fact]
    public void TakesPositiveResultOnSameValues()
    {
        IBool condition = new GreaterThanOrEqualCondition<int>(new Int(10), new Int(10), new Int(10));
        Assert.True(condition.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnAscendingValues()
    {
        IBool condition = new GreaterThanOrEqualCondition<int>(new Int(10), new Int(11), new Int(12));
        Assert.False(condition.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnDescendingValues()
    {
        IBool condition = new GreaterThanOrEqualCondition<int>(new Int(12), new Int(11), new Int(10));
        Assert.True(condition.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnAllAscendingOneSameValue()
    {
        IBool condition = new GreaterThanOrEqualCondition<int>(new Int(11), new Int(12), new Int(13), new Int(13));
        Assert.False(condition.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnAllDescendingOneSameValue()
    {
        IBool condition = new GreaterThanOrEqualCondition<int>(new Int(12), new Int(11), new Int(10), new Int(10));
        Assert.True(condition.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnSingleElementInCollection()
    {
        IBool condition = new GreaterThanOrEqualCondition<int>(new Int(10));
        Assert.True(condition.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyCollection()
    {
        IBool condition = new GreaterThanOrEqualCondition<int>(Enumerable.Empty<INumber<int>>());
        Assert.Throws<ArgumentException>(() => condition.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new GreaterThanOrEqualCondition<float>(new Float(10)).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new GreaterThanOrEqualCondition<float>(new Float(10)).ToString());
    }
}