using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations.Tests;

public sealed record RoundedNumberTests
{
    [Fact]
    public void RoundFloat()
    {
        const float a = 10.3F;

        INumber<float> rounded = new RoundedNumber<float>(new Float(a));

        Assert.Equal(float.Round(a), rounded.NumberValue);
    }

    [Fact]
    public void RoundDouble()
    {
        const double a = -10;

        INumber<double> rounded = new RoundedNumber<double>(new Double(a));

        Assert.Equal(double.Round(a), rounded.NumberValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new RoundedNumber<float>(new Float(10)).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new RoundedNumber<float>(new Float(10)).ToString()
        );
    }
}
