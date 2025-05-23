using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations.Tests;

public sealed record AbsTests
{
    [Fact]
    public void TakeFloatAbs()
    {
        const float expected = -10.3F;

        INumber<float> abs = new Abs<float>(new Float(expected));

        Assert.Equal(float.Abs(expected), abs.Value);
    }

    [Fact]
    public void TakeIntAbs()
    {
        const int expected = -10;

        INumber<int> abs = new Abs<int>(new Int(expected));

        Assert.Equal(int.Abs(expected), abs.Value);
    }

    [Fact]
    public void TakeDoubleAbs()
    {
        const double expected = -10;

        INumber<double> abs = new Abs<double>(new Double(expected));

        Assert.Equal(double.Abs(expected), abs.Value);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new Abs<float>(new Float(10)).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new Abs<float>(new Float(10)).ToString());
    }
}