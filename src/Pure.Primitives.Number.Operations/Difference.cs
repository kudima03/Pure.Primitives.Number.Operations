using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations;

public sealed record Difference<T> : INumber<T> where T : System.Numerics.INumber<T>
{
    private readonly IEnumerable<INumber<T>> _values;

    public Difference(params INumber<T>[] values) : this(values.AsReadOnly()) { }

    public Difference(IEnumerable<INumber<T>> values)
    {
        _values = values;
    }

    T INumber<T>.Value
    {
        get
        {
            if (!_values.Any())
            {
                throw new ArgumentException();
            }

            return _values.Select(x => x.Value).Aggregate((number1, number2) => number1 - number2);
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