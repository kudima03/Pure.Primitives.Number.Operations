using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations;

public sealed record Max<T> : INumber<T> where T : System.Numerics.INumber<T>
{
    private readonly IEnumerable<INumber<T>> _numbers;

    public Max(params INumber<T>[] numbers) : this(numbers.AsReadOnly()) { }

    public Max(IEnumerable<INumber<T>> numbers)
    {
        _numbers = numbers;
    }

    T INumber<T>.Value => _numbers.Select(x => x.Value).Max()!;
}