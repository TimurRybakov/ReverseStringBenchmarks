using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

using ReverseStringBenchmarks.StringReverseners;

namespace ReverseStringBenchmarks;

[Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
[MemoryDiagnoser]
public class Benchmarks
{
    private string? _input;

    [Params(10, 100, 1000)]
    public int InputLength { get; set; }

    [GlobalSetup]
    public void SetInput()
    {
        _input = RandomString(InputLength);
    }

    [Benchmark(Baseline = true)]
    public string? HeapSpanStringReversener() => ReverseWith(new HeapSpanStringReversener());

    [Benchmark]
    public string? StackSpanStringReversener() => ReverseWith(new StackSpanStringReversener());

    [Benchmark]
    public string? LinqStringReversener() => ReverseWith(new LinqStringReversener());

    [Benchmark]
    public string? StringCreateReversener() => ReverseWith(new StringCreateReversener());

    [Benchmark]
    public string? XorStringReversener() => ReverseWith(new XorStringReversener());

    [Benchmark]
    public string? ArrayStringReversener() => ReverseWith(new ArrayStringReversener());

    [Benchmark]
    public string? PointerStringReversener() => ReverseWith(new PointerStringReversener());

    private string? ReverseWith(IStringReversener reversener)
    {
        return reversener.Reverse(_input);
    }

    private static readonly Random Random = new ();

    private static string RandomString(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[Random.Next(s.Length)]).ToArray());
    }
}
