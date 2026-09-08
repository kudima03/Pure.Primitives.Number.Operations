using Pure.Primitives.Abstractions.Bool;

namespace Pure.Primitives.Number.Operations.Tests;

public sealed record IsNonNegativeConditionTests
{
    [Fact]
    public void TakesPositiveResultOnPositiveValue()
    {
        IBool condition = new IsNonNegativeCondition<int>(new Int(10));
        Assert.True(condition.BoolValue);
    }

    [Fact]
    public void TakesPositiveResultOnZero()
    {
        IBool condition = new IsNonNegativeCondition<int>(new Int(0));
        Assert.True(condition.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnNegativeValue()
    {
        IBool condition = new IsNonNegativeCondition<int>(new Int(-10));
        Assert.False(condition.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new IsNonNegativeCondition<float>(new Float(10)).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new IsNonNegativeCondition<float>(new Float(10)).ToString()
        );
    }
}
