# ReverseStringBenchmarks

A simple BenchmarkDotNet project that benchmarks different algorithms for string reversion (i.e. 'ABC' -> 'CBA').

Here is some results:

```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22621.4037/22H2/2022Update/SunValley2)
Unknown processor
.NET SDK 8.0.403
  [Host]     : .NET 8.0.10 (8.0.1024.46610), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.10 (8.0.1024.46610), X64 RyuJIT AVX2


```
| Method                    | InputLength | Mean        | Error      | StdDev     | Median      | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|-------------------------- |------------ |------------:|-----------:|-----------:|------------:|------:|--------:|-------:|-------:|----------:|------------:|
| PointerStringReversener   | 10          |    14.64 ns |   1.020 ns |   2.992 ns |    13.88 ns |  0.36 |    0.09 | 0.0038 |      - |      24 B |        0.20 |
| StringCreateReversener    | 10          |    28.57 ns |   1.399 ns |   3.990 ns |    27.89 ns |  0.71 |    0.15 | 0.0115 |      - |      72 B |        0.60 |
| StackSpanStringReversener | 10          |    40.08 ns |   2.706 ns |   7.851 ns |    38.02 ns |  1.00 |    0.25 | 0.0114 |      - |      72 B |        0.60 |
| LinqStringReversener      | 10          |    40.36 ns |   1.762 ns |   4.999 ns |    39.85 ns |  1.00 |    0.20 | 0.0191 |      - |     120 B |        1.00 |
| HeapSpanStringReversener  | 10          |    41.20 ns |   2.214 ns |   6.388 ns |    40.20 ns |  1.02 |    0.23 | 0.0191 |      - |     120 B |        1.00 |
| ArrayStringReversener     | 10          |    41.68 ns |   1.289 ns |   3.699 ns |    41.97 ns |  1.04 |    0.19 | 0.0191 |      - |     120 B |        1.00 |
| XorStringReversener       | 10          |    42.54 ns |   1.090 ns |   3.056 ns |    42.33 ns |  1.06 |    0.18 | 0.0191 |      - |     120 B |        1.00 |
|                           |             |             |            |            |             |       |         |        |        |           |             |
| StringCreateReversener    | 100         |    51.82 ns |   1.626 ns |   4.587 ns |    50.88 ns |  0.29 |    0.05 | 0.0395 |      - |     248 B |        0.53 |
| PointerStringReversener   | 100         |    57.04 ns |   2.239 ns |   6.167 ns |    56.06 ns |  0.32 |    0.06 | 0.0038 |      - |      24 B |        0.05 |
| LinqStringReversener      | 100         |    94.89 ns |   3.316 ns |   9.622 ns |    94.12 ns |  0.53 |    0.10 | 0.0751 |      - |     472 B |        1.00 |
| ArrayStringReversener     | 100         |   106.90 ns |   5.332 ns |  15.720 ns |   104.63 ns |  0.60 |    0.13 | 0.0752 |      - |     472 B |        1.00 |
| StackSpanStringReversener | 100         |   178.04 ns |  10.101 ns |  29.466 ns |   171.06 ns |  1.00 |    0.23 | 0.0393 |      - |     248 B |        0.53 |
| HeapSpanStringReversener  | 100         |   183.45 ns |  10.817 ns |  31.552 ns |   177.66 ns |  1.03 |    0.25 | 0.0751 |      - |     472 B |        1.00 |
| XorStringReversener       | 100         |   198.79 ns |   6.439 ns |  18.475 ns |   196.72 ns |  1.11 |    0.21 | 0.0751 |      - |     472 B |        1.00 |
|                           |             |             |            |            |             |       |         |        |        |           |             |
| StringCreateReversener    | 1000        |   496.83 ns |  44.691 ns | 131.771 ns |   491.76 ns |  0.37 |    0.11 | 0.3262 |      - |    2048 B |       0.503 |
| PointerStringReversener   | 1000        |   532.64 ns |  24.622 ns |  70.249 ns |   521.06 ns |  0.40 |    0.08 | 0.0038 |      - |      24 B |       0.006 |
| ArrayStringReversener     | 1000        |   737.25 ns |  57.696 ns | 168.303 ns |   713.63 ns |  0.55 |    0.15 | 0.6485 | 0.0038 |    4072 B |       1.000 |
| LinqStringReversener      | 1000        |   850.35 ns |  68.747 ns | 202.702 ns |   841.65 ns |  0.64 |    0.17 | 0.6485 |      - |    4072 B |       1.000 |
| HeapSpanStringReversener  | 1000        | 1,362.66 ns |  71.861 ns | 199.128 ns | 1,338.50 ns |  1.02 |    0.20 | 0.6485 |      - |    4072 B |       1.000 |
| XorStringReversener       | 1000        | 1,643.78 ns |  69.772 ns | 197.932 ns | 1,613.04 ns |  1.23 |    0.22 | 0.6485 | 0.0038 |    4072 B |       1.000 |
| StackSpanStringReversener | 1000        | 2,348.23 ns | 233.589 ns | 688.742 ns | 2,119.04 ns |  1.76 |    0.57 | 0.3242 |      - |    2048 B |       0.503 |
