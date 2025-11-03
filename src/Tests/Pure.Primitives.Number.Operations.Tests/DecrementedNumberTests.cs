using Pure.Primitives.Abstractions.Number;
using Pure.Primitives.Random.Number;

namespace Pure.Primitives.Number.Operations.Tests;

public sealed record DecrementedNumberTests
{
    [Fact]
    public void DecrementFloat()
    {
        INumber<float> sample = new RandomFloat();

        INumber<float> number = new DecrementedNumber<float>(sample);

        Assert.Equal(sample.NumberValue - 1, number.NumberValue);
    }

    [Fact]
    public void DecrementInt()
    {
        INumber<int> sample = new RandomInt();

        INumber<int> number = new DecrementedNumber<int>(sample);

        Assert.Equal(sample.NumberValue - 1, number.NumberValue);
    }

    [Fact]
    public void DecrementDouble()
    {
        const double sample = -10.763467567;

        INumber<double> number = new DecrementedNumber<double>(new Double(sample));

        Assert.Equal(sample - 1, number.NumberValue);
    }

    [Fact]
    public void ThrowsExceptionOnUnderflow()
    {
        INumber<int> valueWithUnderflow = new DecrementedNumber<int>(new MinInt());
        _ = Assert.Throws<OverflowException>(() => valueWithUnderflow.NumberValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new DecrementedNumber<float>(new Float(10)).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new DecrementedNumber<float>(new Float(10)).ToString()
        );
    }
}
