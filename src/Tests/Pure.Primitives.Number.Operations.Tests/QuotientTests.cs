using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations.Tests;

public sealed record QuotientTests
{
    [Fact]
    public void DividesCorrectly()
    {
        const float a = 10.1F;
        const float b = 20.2F;
        const float c = 30.3F;

        INumber<float> quotient = new Quotient<float>(new Float(a), new Float(b), new Float(c));

        Assert.Equal(a / b / c, quotient.Value);
    }

    [Fact]
    public void DividesOnZeroCorrectly()
    {
        const float a = 10.1F;
        const float b = 20.2F;
        const float c = 0;

        INumber<float> quotient = new Quotient<float>(new Float(a), new Float(b), new Float(c));

        Assert.Equal(float.PositiveInfinity, quotient.Value);
    }

    [Fact]
    public void DividesEmptyCollection()
    {
        Assert.Equal(0, new Quotient<float>(Enumerable.Empty<INumber<float>>()).Value);
    }
}