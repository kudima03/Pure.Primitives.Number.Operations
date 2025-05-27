using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations;

public sealed record DecrementedNumber<T> : INumber<T> where T : System.Numerics.INumber<T>
{
    private readonly INumber<T> _number;

    public DecrementedNumber(INumber<T> number)
    {
        _number = number;
    }

    T INumber<T>.Value => _number.Value - T.One;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}