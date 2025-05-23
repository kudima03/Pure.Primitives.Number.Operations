using Pure.Primitives.Abstractions.Number;

namespace Pure.Primitives.Number.Operations.Tests;
public sealed record SumTests
{
    [Fact]
    public void TakesSum()
    {
        const int a = 10;
        const int b = 20;
        const int c = 30;
        INumber<int> sum = new Sum<int>(new Int(a), new Int(b), new Int(c));
        Assert.Equal(a + b + c, sum.Value);
    }

    [Fact]
    public void TakesSumFromLargeDoubleCollection()
    {
        Random random = new Random();
        IEnumerable<double> numbers = Enumerable.Range(0, 10000).Select(_ => random.NextDouble()).ToArray();
        INumber<double> sum = new Sum<double>(numbers.Select(x => new Double(x)));
        Assert.Equal(numbers.Sum(), sum.Value);
    }

    [Fact]
    public void ThrowsExceptionOnEmptyCollection()
    {
        INumber<int> sum = new Sum<int>(Enumerable.Empty<INumber<int>>());
        Assert.Throws<InvalidOperationException>(() => sum.Value);
    }
}