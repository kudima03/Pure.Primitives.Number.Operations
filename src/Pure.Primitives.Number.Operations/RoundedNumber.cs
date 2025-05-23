using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations;

public sealed record RoundedNumber<T> : INumber<T> where T : System.Numerics.IFloatingPoint<T>
{
    private readonly INumber<T> _number;

    public RoundedNumber(INumber<T> number)
    {
        _number = number;
    }

    public T Value => T.Round(_number.Value);
}