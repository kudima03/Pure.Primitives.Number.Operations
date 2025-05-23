using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations.Tests;

public sealed record RoundedNumberTests
{
    [Fact]
    public void RoundFloat()
    {
        const float a = 10.3F;

        INumber<float> rounded = new RoundedNumber<float>(new Float(a));

        Assert.Equal(float.Round(a), rounded.Value);
    }

    [Fact]
    public void RoundDouble()
    {
        const double a = -10;

        INumber<double> rounded = new RoundedNumber<double>(new Double(a));

        Assert.Equal(double.Round(a), rounded.Value);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<InvalidOperationException>(() => new RoundedNumber<float>(new Float(10)).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<InvalidOperationException>(() => new RoundedNumber<float>(new Float(10)).ToString());
    }
}