# ReverseStringBenchmarks

A simple BenchmarkDotNet project that benchmarks different algorithms for string reversion (i.e. 'ABC' -> 'CBA').

Here is some results:

```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.5073/22H2/2022Update)
Intel Core i7-6700 CPU 3.40GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.307
  [Host]     : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2


```
| Method                      | InputLength | Mean         | Error      | StdDev     | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|---------------------------- |------------ |-------------:|-----------:|-----------:|------:|--------:|-------:|----------:|------------:|
| PointerReversener           | 10          |     9.414 ns |  0.2146 ns |  0.2865 ns |  0.31 |    0.01 | 0.0057 |      24 B |        0.20 |
| PointerStringCopyReversener | 10          |    18.282 ns |  0.0910 ns |  0.0711 ns |  0.60 |    0.01 | 0.0172 |      72 B |        0.60 |
| StringCreateReversener      | 10          |    18.561 ns |  0.3000 ns |  0.2806 ns |  0.61 |    0.01 | 0.0172 |      72 B |        0.60 |
| ArrayReversener             | 10          |    27.642 ns |  0.4788 ns |  0.4479 ns |  0.91 |    0.02 | 0.0287 |     120 B |        1.00 |
| StackSpanReversener         | 10          |    28.974 ns |  0.4620 ns |  0.4322 ns |  0.95 |    0.02 | 0.0172 |      72 B |        0.60 |
| HeapSpanReversener          | 10          |    30.370 ns |  0.4730 ns |  0.4424 ns |  1.00 |    0.02 | 0.0287 |     120 B |        1.00 |
| XorReversener               | 10          |    33.992 ns |  0.1856 ns |  0.1550 ns |  1.12 |    0.02 | 0.0287 |     120 B |        1.00 |
| StringBuilderReversener     | 10          |    46.717 ns |  1.0027 ns |  1.6475 ns |  1.54 |    0.06 | 0.0401 |     168 B |        1.40 |
|                             |             |              |            |            |       |         |        |           |             |
| StringCreateReversener      | 100         |    35.163 ns |  0.3936 ns |  0.3681 ns |  0.35 |    0.00 | 0.0592 |     248 B |        0.53 |
| PointerReversener           | 100         |    50.312 ns |  0.3849 ns |  0.3214 ns |  0.50 |    0.00 | 0.0057 |      24 B |        0.05 |
| ArrayReversener             | 100         |    53.886 ns |  0.9300 ns |  0.8700 ns |  0.54 |    0.01 | 0.1128 |     472 B |        1.00 |
| PointerStringCopyReversener | 100         |    57.428 ns |  0.2687 ns |  0.2244 ns |  0.58 |    0.00 | 0.0592 |     248 B |        0.53 |
| HeapSpanReversener          | 100         |    99.770 ns |  0.7141 ns |  0.6330 ns |  1.00 |    0.01 | 0.1128 |     472 B |        1.00 |
| StackSpanReversener         | 100         |   124.870 ns |  0.7170 ns |  0.6356 ns |  1.25 |    0.01 | 0.0591 |     248 B |        0.53 |
| XorReversener               | 100         |   137.214 ns |  2.7514 ns |  3.1685 ns |  1.38 |    0.03 | 0.1128 |     472 B |        1.00 |
| StringBuilderReversener     | 100         |   221.350 ns |  1.8175 ns |  1.6112 ns |  2.22 |    0.02 | 0.1242 |     520 B |        1.10 |
|                             |             |              |            |            |       |         |        |           |             |
| StringCreateReversener      | 1000        |   189.929 ns |  3.2694 ns |  3.0582 ns |  0.24 |    0.00 | 0.4897 |    2048 B |       0.503 |
| ArrayReversener             | 1000        |   323.436 ns |  2.7876 ns |  2.4712 ns |  0.40 |    0.01 | 0.9732 |    4072 B |       1.000 |
| PointerReversener           | 1000        |   465.021 ns |  2.5333 ns |  1.9779 ns |  0.58 |    0.01 | 0.0057 |      24 B |       0.006 |
| PointerStringCopyReversener | 1000        |   471.685 ns |  9.1704 ns | 11.2621 ns |  0.59 |    0.02 | 0.4897 |    2048 B |       0.503 |
| HeapSpanReversener          | 1000        |   805.653 ns | 10.5204 ns |  9.3261 ns |  1.00 |    0.02 | 0.9727 |    4072 B |       1.000 |
| StackSpanReversener         | 1000        | 1,131.602 ns |  9.5431 ns |  8.4597 ns |  1.40 |    0.02 | 0.4883 |    2048 B |       0.503 |
| XorReversener               | 1000        | 1,192.833 ns | 20.8959 ns | 19.5460 ns |  1.48 |    0.03 | 0.9727 |    4072 B |       1.000 |
| StringBuilderReversener     | 1000        | 2,165.372 ns | 16.4737 ns | 14.6035 ns |  2.69 |    0.03 | 0.9842 |    4120 B |       1.012 |
