<center><h1 align="center">UnionType</h1></center>
<div align="center">

    Powerful, low consumption, and highly scalable type for c#.

[![.NET Build](https://github.com/Cricle/UnionType/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Cricle/UnionType/actions/workflows/dotnet.yml)
[![codecov](https://codecov.io/gh/Cricle/UnionType/branch/main/graph/badge.svg?token=kIuE6hSsO3)](https://codecov.io/gh/Cricle/UnionType)

</div>

# What is this

It provide an union type struct, for strongly typed c# language.

# How to implement

Use `Memory mask` to make struct has `16(maximum primary type bytes)+1(type store)` bytes, it can be store primary types.

Object store use `GCHandle` to pin memory. 

# Samples

> `samples/UnionType.Sample`

In normal use case

```csharp
//Define an int type
UnionValue uv=123;

//Cast back

uv.Int;

```

In serialize case.(Can see `UnionValueToBytesHelperTest.cs`)

# Performace

``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19045.2364)
Intel Core i5-9400F CPU 2.90GHz (Coffee Lake), 1 CPU, 6 logical and 6 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 6.0.12 (6.0.1222.56807), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.12 (6.0.1222.56807), X64 RyuJIT AVX2


```
|  Method |  Count |            Mean |         Error |        StdDev |          Median | Ratio | RatioSD |      Gen0 |      Gen1 |     Gen2 |   Allocated | Alloc Ratio |
|-------- |------- |----------------:|--------------:|--------------:|----------------:|------:|--------:|----------:|----------:|---------:|------------:|------------:|
| **Decimal** |    **500** |        **831.4 ns** |      **16.44 ns** |      **30.47 ns** |        **825.3 ns** |  **1.00** |    **0.00** |    **1.7033** |         **-** |        **-** |     **7.84 KB** |        **1.00** |
|   Union |    500 |      2,857.0 ns |      24.39 ns |      21.62 ns |      2,857.1 ns |  3.41 |    0.15 |    1.8082 |         - |        - |     8.33 KB |        1.06 |
|     Box |    500 |      2,617.9 ns |      52.26 ns |      58.09 ns |      2,609.7 ns |  3.13 |    0.15 |    4.2534 |    0.2823 |        - |    19.55 KB |        2.50 |
|         |        |                 |               |               |                 |       |         |           |           |          |             |             |
| **Decimal** | **500000** |  **3,268,249.8 ns** | **106,037.86 ns** | **312,655.03 ns** |  **3,361,560.4 ns** |  **1.00** |    **0.00** |  **234.3750** |  **234.3750** | **234.3750** |   **7812.6 KB** |        **1.00** |
|   Union | 500000 |  3,795,705.6 ns |  71,548.71 ns | 102,613.02 ns |  3,778,834.8 ns |  1.19 |    0.12 |  281.2500 |  281.2500 | 281.2500 |  8300.89 KB |        1.06 |
|     Box | 500000 | 24,020,219.0 ns | 476,741.53 ns | 713,564.27 ns | 24,054,226.6 ns |  7.55 |    0.83 | 3031.2500 | 1562.5000 | 937.5000 | 19531.72 KB |        2.50 |
