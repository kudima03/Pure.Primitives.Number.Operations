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

    public T Value => !_values.Any() ? T.Zero : _values.Select(x => x.Value).Aggregate((number1, number2) => number1 - number2);
}