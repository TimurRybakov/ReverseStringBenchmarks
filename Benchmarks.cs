using System.Collections.Immutable;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

using ReverseStringBenchmarks.StringReverseners;

namespace ReverseStringBenchmarks;

[Config(typeof(Config))]
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

    [Benchmark]
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
    public string? GlobalHeapPointerReversener() => ReverseWith(new GlobalHeapPointerReversener());

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

    private class Config : ManualConfig
    {
        public Config() => Orderer = new CustomOrderer();

        private class CustomOrderer : IOrderer
        {
            public bool SeparateLogicalGroups => true;

            public IEnumerable<BenchmarkCase> GetExecutionOrder(
                ImmutableArray<BenchmarkCase> benchmarksCase,
                IEnumerable<BenchmarkLogicalGroupRule>? order = null) => benchmarksCase.OrderBy(x => x.Parameters["InputLength"]);

            public string? GetHighlightGroupKey(BenchmarkCase benchmarkCase) => benchmarkCase.Parameters["InputLength"].ToString();

            public string? GetLogicalGroupKey(ImmutableArray<BenchmarkCase> allBenchmarksCases, BenchmarkCase benchmarkCase) =>
                benchmarkCase.Job.DisplayInfo + "_" + benchmarkCase.Parameters.DisplayInfo;

            public IEnumerable<IGrouping<string, BenchmarkCase>> GetLogicalGroupOrder(
                IEnumerable<IGrouping<string, BenchmarkCase>> logicalGroups,
                IEnumerable<BenchmarkLogicalGroupRule>? order = null) =>
                logicalGroups.OrderBy(it => it.Key);

            public IEnumerable<BenchmarkCase> GetSummaryOrder(ImmutableArray<BenchmarkCase> benchmarksCases, Summary summary) =>
                benchmarksCases
                    .OrderBy(x => x.Parameters["InputLength"])
                    .ThenBy(keySelector => summary[keySelector]?.ResultStatistics?.Mean);

        }
    }
}
