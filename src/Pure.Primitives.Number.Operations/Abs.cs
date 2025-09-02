using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations;

public sealed record Abs<T> : INumber<T>
    where T : System.Numerics.INumber<T>
{
    private readonly INumber<T> _number;

    public Abs(INumber<T> number)
    {
        _number = number;
    }

    T INumber<T>.NumberValue => T.Abs(_number.NumberValue);

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
