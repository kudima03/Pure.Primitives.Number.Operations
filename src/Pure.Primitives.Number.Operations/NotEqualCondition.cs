using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations;

public sealed record NotEqualCondition<T> : IBool
    where T : System.Numerics.INumber<T>
{
    private readonly IEnumerable<INumber<T>> _values;

    public NotEqualCondition(params IEnumerable<INumber<T>> values)
    {
        _values = values;
    }

    bool IBool.BoolValue
    {
        get
        {
            return !_values.Any() ? throw new ArgumentException() : _values.DistinctBy(x => x.NumberValue).Count() > 1;
        }
    }

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}
