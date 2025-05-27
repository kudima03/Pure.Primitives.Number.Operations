using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations.Tests;

public sealed record IncrementedNumberTests
{
    [Fact]
    public void IncrementFloat()
    {
        const float sample = 10.3F;

        INumber<float> number = new IncrementedNumber<float>(new Float(sample));

        Assert.Equal(sample + 1, number.Value);
    }

    [Fact]
    public void IncrementInt()
    {
        const int sample = 0;

        INumber<int> number = new IncrementedNumber<int>(new Int(sample));

        Assert.Equal(sample + 1, number.Value);
    }

    [Fact]
    public void IncrementDouble()
    {
        const double sample = -10.763467567;

        INumber<double> number = new IncrementedNumber<double>(new Double(sample));

        Assert.Equal(sample + 1, number.Value);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        Assert.Throws<NotSupportedException>(() => new IncrementedNumber<float>(new Float(10)).GetHashCode());
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        Assert.Throws<NotSupportedException>(() => new IncrementedNumber<float>(new Float(10)).ToString());
    }
}