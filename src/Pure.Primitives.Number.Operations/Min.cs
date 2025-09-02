using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations;

public sealed record Min<T> : INumber<T>
    where T : System.Numerics.INumber<T>
{
    private readonly IEnumerable<INumber<T>> _numbers;

    public Min(params IEnumerable<INumber<T>> numbers)
    {
        _numbers = numbers;
    }

    T INumber<T>.NumberValue
    {
        get
        {
            return !_numbers.Any() ? throw new ArgumentException() : _numbers.Min(x => x.NumberValue)!;
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
