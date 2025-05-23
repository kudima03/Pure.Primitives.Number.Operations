using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations;

public sealed record Product<T> : INumber<T> where T : System.Numerics.INumber<T>
{
    private readonly IEnumerable<INumber<T>> _values;

    public Product(params INumber<T>[] values) : this(values.AsReadOnly()) { }

    public Product(IEnumerable<INumber<T>> values)
    {
        _values = values;
    }

    T INumber<T>.Value => _values.Select(x => x.Value).Aggregate((number1, number2) => number1 * number2);
}