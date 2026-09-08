using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations;

public sealed record IsNonNegativeCondition<T> : IBool
    where T : System.Numerics.INumber<T>
{
    private readonly IBool _condition;

    public IsNonNegativeCondition(INumber<T> value)
    {
        _condition = new GreaterThanOrEqualCondition<T>(value, new Zero<T>());
    }

    bool IBool.BoolValue => _condition.BoolValue;

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
