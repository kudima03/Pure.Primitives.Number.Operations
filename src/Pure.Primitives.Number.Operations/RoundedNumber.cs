using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations;

public sealed record RoundedNumber<T> : INumber<T> where T : System.Numerics.IFloatingPoint<T>
{
    private readonly INumber<T> _number;

    public RoundedNumber(INumber<T> number)
    {
        _number = number;
    }

    T INumber<T>.Value => T.Round(_number.Value);

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}