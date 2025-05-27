using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations;

public sealed record GreaterThanOrEqualCondition<T> : IBool where T : System.Numerics.INumber<T>
{
    private readonly IEnumerable<INumber<T>> _values;

    public GreaterThanOrEqualCondition(params INumber<T>[] values) : this(values.AsReadOnly()) { }

    public GreaterThanOrEqualCondition(IEnumerable<INumber<T>> values)
    {
        _values = values;
    }

    bool IBool.Value
    {
        get
        {
            if (!_values.Any())
            {
                throw new ArgumentException();
            }

            IEnumerable<T> numbers = _values.Select(x => x.Value);

            //Stryker disable once linq
            T previousNumber = numbers.First();

            foreach (T number in numbers.Skip(1))
            {
                if (previousNumber < number)
                {
                    return false;
                }

                previousNumber = number;
            }

            return true;
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