using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations;

public sealed record Quotient<T> : INumber<T> where T : System.Numerics.IFloatingPoint<T>
{
    private readonly IEnumerable<INumber<T>> _values;

    public Quotient(params INumber<T>[] values) : this(values.AsReadOnly()) { }

    public Quotient(IEnumerable<INumber<T>> values)
    {
        _values = values;
    }

    T INumber<T>.Value => _values.Select(x => x.Value).Aggregate((number1, number2) => number1 / number2);

    public override int GetHashCode()
    {
        throw new NotSupportedException();
    }

    public override string ToString()
    {
        throw new NotSupportedException();
    }
}