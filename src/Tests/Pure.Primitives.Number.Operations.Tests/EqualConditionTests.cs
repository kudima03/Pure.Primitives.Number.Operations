using Pure.Primitives.Abstractions.Bool;

namespace Pure.Primitives.Number.Operations.Tests;

public sealed record EqualConditionTests
{
    [Fact]
    public void TakesPositiveResultOnSameValues()
    {
        IBool equality = new EqualCondition<int>(new Int(10), new Int(10), new Int(10));
        Assert.True(equality.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnDifferentValues()
    {
        IBool equality = new EqualCondition<int>(new Int(10), new Int(11), new Int(12));
        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void TakesNegativeResultOnAllSameOneDifferentValue()
    {
        IBool equality = new EqualCondition<int>(
            new Int(10),
            new Int(10),
            new Int(10),
            new Int(12)
        );
        Assert.False(equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyCollection()
    {
        IBool equality = new EqualCondition<int>([]);
        _ = Assert.Throws<ArgumentException>(() => equality.BoolValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new EqualCondition<float>(new Float(10)).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new EqualCondition<float>(new Float(10)).ToString()
        );
    }
}
