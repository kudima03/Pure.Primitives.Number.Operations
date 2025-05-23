using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations.Tests;

public sealed record AbsTests
{
    [Fact]
    public void CorrectFloatAbs()
    {
        const float expected = -10.3F;

        INumber<float> abs = new Abs<float>(new Float(expected));

        Assert.Equal(float.Abs(expected), abs.Value);
    }

    [Fact]
    public void CorrectIntAbs()
    {
        const int expected = -10;

        INumber<int> abs = new Abs<int>(new Int(expected));

        Assert.Equal(int.Abs(expected), abs.Value);
    }

    [Fact]
    public void CorrectDoubleAbs()
    {
        const double expected = -10;

        INumber<double> abs = new Abs<double>(new Double(expected));

        Assert.Equal(double.Abs(expected), abs.Value);
    }
}