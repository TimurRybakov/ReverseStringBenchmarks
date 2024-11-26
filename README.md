# ReverseStringBenchmarks

A simple BenchmarkDotNet project that benchmarks different algorithms for string reversion (i.e. 'ABC' -> 'CBA').

Here is some results:

```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22631.3737/23H2/2023Update/SunValley3)
Unknown processor
.NET SDK 8.0.307
  [Host]     : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.11 (8.0.1124.51707), X64 RyuJIT AVX2


```
| Method                      | InputLength | Mean         | Error      | StdDev     | Median       | Gen0   | Gen1   | Allocated |
|---------------------------- |------------ |-------------:|-----------:|-----------:|-------------:|-------:|-------:|----------:|
| PointerReversener           | 10          |     7.479 ns |  0.1996 ns |  0.1770 ns |     7.471 ns | 0.0029 |      - |      24 B |
| PointerStringCopyReversener | 10          |    15.412 ns |  0.3599 ns |  0.3367 ns |    15.392 ns | 0.0086 |      - |      72 B |
| StringCreateReversener      | 10          |    15.644 ns |  0.3462 ns |  0.3238 ns |    15.680 ns | 0.0086 |      - |      72 B |
| ArrayReversener             | 10          |    23.988 ns |  0.5143 ns |  0.5716 ns |    23.949 ns | 0.0143 |      - |     120 B |
| StackSpanReversener         | 10          |    26.456 ns |  0.5787 ns |  0.5413 ns |    26.621 ns | 0.0086 |      - |      72 B |
| HeapSpanReversener          | 10          |    26.633 ns |  0.5834 ns |  1.2433 ns |    27.142 ns | 0.0143 |      - |     120 B |
| XorReversener               | 10          |    30.663 ns |  0.6518 ns |  0.9756 ns |    30.742 ns | 0.0143 |      - |     120 B |
| StringBuilderReversener     | 10          |    39.741 ns |  0.8418 ns |  1.2073 ns |    39.724 ns | 0.0200 |      - |     168 B |
| GlobalHeapPointerReversener | 10          |   141.037 ns |  2.2652 ns |  2.0081 ns |   140.796 ns | 0.0086 |      - |      72 B |
|                             |             |              |            |            |              |        |        |           |
| StringCreateReversener      | 100         |    26.467 ns |  0.5789 ns |  0.7109 ns |    26.456 ns | 0.0296 |      - |     248 B |
| ArrayReversener             | 100         |    39.995 ns |  0.9862 ns |  2.9078 ns |    38.508 ns | 0.0564 |      - |     472 B |
| PointerReversener           | 100         |    54.064 ns |  0.7378 ns |  0.6901 ns |    53.934 ns | 0.0029 |      - |      24 B |
| PointerStringCopyReversener | 100         |    66.857 ns |  1.1492 ns |  0.9596 ns |    67.107 ns | 0.0296 |      - |     248 B |
| HeapSpanReversener          | 100         |    96.530 ns |  1.9932 ns |  3.7438 ns |    96.041 ns | 0.0564 |      - |     472 B |
| XorReversener               | 100         |   133.439 ns |  2.3778 ns |  2.2242 ns |   133.384 ns | 0.0563 |      - |     472 B |
| StackSpanReversener         | 100         |   140.190 ns |  1.6397 ns |  1.5338 ns |   139.977 ns | 0.0296 |      - |     248 B |
| StringBuilderReversener     | 100         |   150.971 ns |  2.4512 ns |  2.2928 ns |   151.168 ns | 0.0620 |      - |     520 B |
| GlobalHeapPointerReversener | 100         |   483.365 ns | 26.7961 ns | 78.1655 ns |   481.306 ns | 0.0296 |      - |     248 B |
|                             |             |              |            |            |              |        |        |           |
| StringCreateReversener      | 1000        |   114.206 ns |  2.2787 ns |  3.6143 ns |   113.107 ns | 0.2449 |      - |    2048 B |
| ArrayReversener             | 1000        |   195.152 ns |  5.8357 ns | 16.9305 ns |   190.950 ns | 0.4866 | 0.0017 |    4072 B |
| PointerReversener           | 1000        |   522.547 ns |  4.0495 ns |  3.5898 ns |   521.754 ns | 0.0029 |      - |      24 B |
| PointerStringCopyReversener | 1000        |   632.353 ns |  8.6601 ns |  7.6769 ns |   634.736 ns | 0.2441 |      - |    2048 B |
| HeapSpanReversener          | 1000        |   725.488 ns | 13.7403 ns | 38.7547 ns |   706.105 ns | 0.4864 | 0.0010 |    4072 B |
| XorReversener               | 1000        | 1,047.343 ns | 19.7775 ns | 18.4998 ns | 1,046.290 ns | 0.4864 |      - |    4072 B |
| StackSpanReversener         | 1000        | 1,142.372 ns | 22.2800 ns | 25.6577 ns | 1,141.060 ns | 0.2441 |      - |    2048 B |
| StringBuilderReversener     | 1000        | 1,250.211 ns | 19.8470 ns | 18.5649 ns | 1,249.715 ns | 0.4921 | 0.0019 |    4120 B |
| GlobalHeapPointerReversener | 1000        | 2,367.298 ns | 40.6016 ns | 35.9922 ns | 2,363.528 ns | 0.2441 |      - |    2048 B |
