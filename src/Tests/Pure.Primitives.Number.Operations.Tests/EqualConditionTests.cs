using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations.Tests;

public sealed record EqualConditionTests
{
    [Fact]
    public void TakesPositiveResultOnSameValues()
    {
        IBool equality = new EqualCondition<int>(new Int(10), new Int(10), new Int(10));
        Assert.True(equality.Value);
    }

    [Fact]
    public void TakesNegativeResultOnDifferentValues()
    {
        IBool equality = new EqualCondition<int>(new Int(10), new Int(11), new Int(12));
        Assert.False(equality.Value);
    }

    [Fact]
    public void TakesNegativeResultOnAllSameOneDifferentValue()
    {
        IBool equality = new EqualCondition<int>(new Int(10), new Int(10), new Int(10), new Int(12));
        Assert.False(equality.Value);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyCollection()
    {
        IBool equality = new EqualCondition<int>(Enumerable.Empty<INumber<int>>());
        Assert.Throws<InvalidOperationException>(() => equality.Value);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new EqualCondition<float>(new Float(10)).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new EqualCondition<float>(new Float(10)).ToString());
    }
}