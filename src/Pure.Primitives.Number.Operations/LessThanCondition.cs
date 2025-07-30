using Pure.Primitives.Abstractions.Bool;
using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations;

public sealed record LessThanCondition<T> : IBool where T : System.Numerics.INumber<T>
{
    private readonly IEnumerable<INumber<T>> _values;

    public LessThanCondition(params IEnumerable<INumber<T>> values)
    {
        _values = values;
    }

    bool IBool.BoolValue
    {
        get
        {
            if (!_values.Any())
            {
                throw new ArgumentException();
            }

            IEnumerable<T> numbers = _values.Select(x => x.NumberValue);

            //Stryker disable once linq
            T previousNumber = numbers.First();

            foreach (T number in numbers.Skip(1))
            {
                if (previousNumber >= number)
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