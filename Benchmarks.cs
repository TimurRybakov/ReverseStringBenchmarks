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
    public string? HeapSpanReversener() => ReverseWith(new HeapSpanReversener());

    [Benchmark]
    public string? StackSpanReversener() => ReverseWith(new StackSpanReversener());

    [Benchmark]
    public string? StringCreateReversener() => ReverseWith(new StringCreateReversener());

    [Benchmark]
    public string? XorReversener() => ReverseWith(new XorReversener());

    [Benchmark]
    public string? ArrayReversener() => ReverseWith(new ArrayReversener());

    [Benchmark]
    public string? StringBuilderReversener() => ReverseWith(new StringBuilderReversener());

    [Benchmark]
    public string? PointerStringCopyReversener() => ReverseWith(new PointerStringCopyReversener());

    [Benchmark]
    public string? PointerReversener() => ReverseWith(new PointerReversener());

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
