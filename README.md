# ReverseStringBenchmarks

A simple BenchmarkDotNet project that benchmarks different algorithms for string reversion.

Here is some results:

```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22621.4037/22H2/2022Update/SunValley2)
Unknown processor
.NET SDK 8.0.403
  [Host]     : .NET 8.0.10 (8.0.1024.46610), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.10 (8.0.1024.46610), X64 RyuJIT AVX2


```
| Method                    | InputLength | Mean        | Error      | StdDev     | Median      | Ratio | RatioSD |
|-------------------------- |------------ |------------:|-----------:|-----------:|------------:|------:|--------:|
| PointerStringReversener   | 10          |    14.35 ns |   1.446 ns |   4.218 ns |    14.43 ns |  0.35 |    0.13 |
| StringCreateReversener    | 10          |    26.66 ns |   1.368 ns |   3.837 ns |    26.25 ns |  0.66 |    0.16 |
| LinqStringReversener      | 10          |    37.31 ns |   1.423 ns |   4.084 ns |    37.06 ns |  0.92 |    0.21 |
| StackSpanStringReversener | 10          |    41.28 ns |   2.830 ns |   8.212 ns |    40.65 ns |  1.02 |    0.29 |
| HeapSpanStringReversener  | 10          |    42.22 ns |   2.982 ns |   8.650 ns |    40.83 ns |  1.04 |    0.30 |
| XorStringReversener       | 10          |    44.59 ns |   2.004 ns |   5.685 ns |    43.51 ns |  1.10 |    0.26 |
| ArrayStringReversener     | 10          |    46.86 ns |   3.064 ns |   9.035 ns |    46.12 ns |  1.15 |    0.32 |
|                           |             |             |            |            |             |       |         |
| StringCreateReversener    | 100         |    63.33 ns |   3.521 ns |  10.327 ns |    60.39 ns |  0.35 |    0.09 |
| PointerStringReversener   | 100         |    75.33 ns |   8.812 ns |  25.983 ns |    67.63 ns |  0.42 |    0.17 |
| ArrayStringReversener     | 100         |   116.28 ns |   9.398 ns |  27.563 ns |   111.33 ns |  0.64 |    0.20 |
| LinqStringReversener      | 100         |   121.83 ns |   8.687 ns |  25.615 ns |   116.40 ns |  0.67 |    0.19 |
| StackSpanStringReversener | 100         |   186.59 ns |   9.535 ns |  27.964 ns |   185.56 ns |  1.03 |    0.25 |
| HeapSpanStringReversener  | 100         |   187.77 ns |  12.994 ns |  38.110 ns |   179.21 ns |  1.04 |    0.29 |
| XorStringReversener       | 100         |   206.53 ns |   9.185 ns |  26.056 ns |   203.83 ns |  1.14 |    0.27 |
|                           |             |             |            |            |             |       |         |
| StringCreateReversener    | 1000        |   373.95 ns |  33.895 ns |  99.409 ns |   346.20 ns |  0.28 |    0.09 |
| PointerStringReversener   | 1000        |   514.53 ns |  26.197 ns |  76.417 ns |   507.04 ns |  0.38 |    0.09 |
| LinqStringReversener      | 1000        |   681.29 ns |  67.869 ns | 193.633 ns |   627.07 ns |  0.50 |    0.17 |
| ArrayStringReversener     | 1000        |   700.79 ns |  52.592 ns | 153.412 ns |   658.65 ns |  0.52 |    0.15 |
| HeapSpanStringReversener  | 1000        | 1,411.17 ns |  99.403 ns | 288.387 ns | 1,328.53 ns |  1.04 |    0.29 |
| StackSpanStringReversener | 1000        | 1,521.09 ns |  79.575 ns | 221.823 ns | 1,495.73 ns |  1.12 |    0.27 |
| XorStringReversener       | 1000        | 1,565.02 ns | 124.640 ns | 359.615 ns | 1,430.96 ns |  1.15 |    0.34 |
