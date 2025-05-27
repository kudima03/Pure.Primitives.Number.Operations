using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations.Tests;

public sealed record DecrementedNumberTests
{
    [Fact]
    public void DecrementFloat()
    {
        const float sample = 10.3F;

        INumber<float> number = new DecrementedNumber<float>(new Float(sample));

        Assert.Equal(sample - 1, number.Value);
    }

    [Fact]
    public void DecrementInt()
    {
        const int sample = 0;

        INumber<int> number = new DecrementedNumber<int>(new Int(sample));

        Assert.Equal(sample - 1, number.Value);
    }

    [Fact]
    public void DecrementDouble()
    {
        const double sample = -10.763467567;

        INumber<double> number = new DecrementedNumber<double>(new Double(sample));

        Assert.Equal(sample - 1, number.Value);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new DecrementedNumber<float>(new Float(10)).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new DecrementedNumber<float>(new Float(10)).ToString());
    }
}