using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations.Tests;

public sealed record QuotientTests
{
    [Fact]
    public void TakesQuotient()
    {
        const float a = 10.1F;
        const float b = 20.2F;
        const float c = 30.3F;

        INumber<float> quotient = new Quotient<float>(
            new Float(a),
            new Float(b),
            new Float(c)
        );

        Assert.Equal(a / b / c, quotient.NumberValue);
    }

    [Fact]
    public void TakesQuotientOnZeroAsInfinity()
    {
        const float a = 10.1F;
        const float b = 20.2F;
        const float c = 0;

        INumber<float> quotient = new Quotient<float>(
            new Float(a),
            new Float(b),
            new Float(c)
        );

        Assert.Equal(float.PositiveInfinity, quotient.NumberValue);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyCollection()
    {
        INumber<float> quotient = new Quotient<float>([]);
        _ = Assert.Throws<ArgumentException>(() => quotient.NumberValue);
    }

    [Fact]
    public void ThrowsExceptionOnGetHashCode()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new Quotient<float>(new Float(10)).GetHashCode()
        );
    }

    [Fact]
    public void ThrowsExceptionOnToString()
    {
        _ = Assert.Throws<NotSupportedException>(() =>
            new Quotient<float>(new Float(10)).ToString()
        );
    }
}
