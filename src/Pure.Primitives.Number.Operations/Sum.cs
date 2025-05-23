using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations;

public sealed record Sum<T> : INumber<T> where T : System.Numerics.INumber<T>
{
    private readonly IEnumerable<INumber<T>> _values;

    public Sum(params INumber<T>[] values) : this(values.AsReadOnly()) { }

    public Sum(IEnumerable<INumber<T>> values)
    {
        _values = values;
    }

    public T Value => !_values.Any()
        ? T.Zero
        : _values.Select(number => number.Value).Aggregate((number1, number2) => number1 + number2);
}