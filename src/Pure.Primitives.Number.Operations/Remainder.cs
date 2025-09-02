using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations;

public sealed record Remainder<T> : INumber<T>
    where T : System.Numerics.INumber<T>
{
    private readonly IEnumerable<INumber<T>> _values;

    public Remainder(params IEnumerable<INumber<T>> values)
    {
        _values = values;
    }

    T INumber<T>.NumberValue
    {
        get
        {
            return !_values.Any()
                ? throw new ArgumentException()
                : _values
                .Select(x => x.NumberValue)
                .Aggregate((number1, number2) => number1 % number2);
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
