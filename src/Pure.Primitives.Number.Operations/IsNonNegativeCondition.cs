using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations;

public sealed record IsNonNegativeCondition<T> : IBool
    where T : System.Numerics.INumber<T>
{
    private readonly INumber<T> _value;

    public IsNonNegativeCondition(INumber<T> value)
    {
        _value = value;
    }

    bool IBool.BoolValue => _value.NumberValue >= T.Zero;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
