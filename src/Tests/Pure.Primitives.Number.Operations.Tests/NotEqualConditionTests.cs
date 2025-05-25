using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations.Tests;

public sealed record NotEqualConditionTests
{
    [Fact]
    public void TakesNegativeResultOnSameValues()
    {
        IBool equality = new NotEqualCondition<int>(new Int(10), new Int(10), new Int(10));
        Assert.False(equality.Value);
    }

    [Fact]
    public void TakesPositiveResultOnDifferentValues()
    {
        IBool equality = new NotEqualCondition<int>(new Int(10), new Int(11), new Int(12));
        Assert.True(equality.Value);
    }

    [Fact]
    public void TakesPositiveResultOnAllSameOneDifferentValue()
    {
        IBool equality = new NotEqualCondition<int>(new Int(10), new Int(10), new Int(10), new Int(12));
        Assert.True(equality.Value);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyCollection()
    {
        IBool equality = new NotEqualCondition<int>(Enumerable.Empty<INumber<int>>());
        Assert.Throws<InvalidOperationException>(() => equality.Value);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<InvalidOperationException>(() => new NotEqualCondition<float>(new Float(10)).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<InvalidOperationException>(() => new NotEqualCondition<float>(new Float(10)).ToString());
    }
}