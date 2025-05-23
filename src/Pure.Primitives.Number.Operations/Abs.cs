using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations;

public sealed record Abs<T> : INumber<T> where T : System.Numerics.INumber<T>
{
    private readonly INumber<T> _number;

    public Abs(INumber<T> number)
    {
        _number = number;
    }

    T INumber<T>.Value => T.Abs(_number.Value);
}