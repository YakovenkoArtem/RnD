```

BenchmarkDotNet v0.13.8, Windows 11 (10.0.22621.2283/22H2/2022Update/SunValley2)
11th Gen Intel Core i7-1165G7 2.80GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 7.0.400
  [Host]     : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.21 (6.0.2123.36311), X64 RyuJIT AVX2


```
| Method                        | Mean       | Error       | StdDev      | Ratio | RatioSD | Gen0   | Gen1   | Gen2   | Allocated | Alloc Ratio |
|------------------------------ |-----------:|------------:|------------:|------:|--------:|-------:|-------:|-------:|----------:|------------:|
| TestCreateNonCollectableClass | 7,145.5 μs | 1,428.02 μs | 4,165.61 μs |  1.00 |    0.00 | 0.3662 | 0.1221 |      - |   2.81 KB |        1.00 |
| TestCreateCollectableClass    |   439.1 μs |    16.72 μs |    49.05 μs |  0.10 |    0.08 | 6.3477 | 6.3477 | 6.3477 |   3.54 KB |        1.26 |
