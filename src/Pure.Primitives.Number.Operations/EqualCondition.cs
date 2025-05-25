using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations;

public sealed record EqualCondition<T> : IBool where T : System.Numerics.INumber<T>
{
    private readonly IEnumerable<INumber<T>> _values;

    public EqualCondition(params INumber<T>[] values) : this(values.AsReadOnly()) { }

    public EqualCondition(IEnumerable<INumber<T>> values)
    {
        _values = values;
    }

    bool IBool.Value
    {
        get
        {
            if (!_values.Any())
            {
                throw new InvalidOperationException();
            }

            return _values.DistinctBy(x => x.Value).Count() == 1;
        }
    }

    public override int GetHashCode()
    {
        throw new InvalidOperationException();
    }

    public override string ToString()
    {
        throw new InvalidOperationException();
    }
}