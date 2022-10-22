<center><h1>UnionType</h1></center>
<center>

[![.NET Build](https://github.com/Cricle/UnionType/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Cricle/UnionType/actions/workflows/dotnet.yml)
[![codecov](https://codecov.io/gh/Cricle/UnionType/branch/main/graph/badge.svg?token=kIuE6hSsO3)](https://codecov.io/gh/Cricle/UnionType)

</center>

# What is this

It provide an union type struct, for strongly typed c# language.

# How to implement

Use `Memory mask` to make struct has `16(maximum primary type bytes)+1(type store)` bytes, it can be store primary types.

Object store use `GCHandle` to pin memory. 

# Performace

``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22000.856/21H2)
AMD Ryzen 7 3700X, 1 CPU, 16 logical and 8 physical cores
.NET SDK=6.0.202
  [Host]     : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT AVX2


```
|  Method |   Count |            Mean |         Error |        StdDev | Ratio | RatioSD |      Gen0 |      Gen1 |      Gen2 |   Allocated | Alloc Ratio |
|-------- |-------- |----------------:|--------------:|--------------:|------:|--------:|----------:|----------:|----------:|------------:|------------:|
| **Decimal** |     **100** |        **481.2 ns** |       **9.64 ns** |      **24.37 ns** |  **1.00** |    **0.00** |    **0.5026** |    **0.0048** |         **-** |     **4.11 KB** |        **1.00** |
|   Union |     100 |      1,129.0 ns |      19.75 ns |      18.47 ns |  2.31 |    0.13 |    0.5322 |    0.0038 |         - |     4.36 KB |        1.06 |
|         |         |                 |               |               |       |         |           |           |           |             |             |
| **Decimal** | **1000000** | **14,744,502.7 ns** | **265,481.51 ns** | **248,331.57 ns** |  **1.00** |    **0.00** | **1484.3750** | **1484.3750** | **1484.3750** |  **32768.9 KB** |        **1.00** |
|   Union | 1000000 | 24,025,315.2 ns | 473,704.53 ns | 842,009.32 ns |  1.62 |    0.06 | 1968.7500 | 1968.7500 | 1968.7500 | 34817.05 KB |        1.06 |
