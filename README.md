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

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22000.1219/21H2)
AMD Ryzen 7 3700X, 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.11 (6.0.1122.52304), X64 RyuJIT AVX2


```
|  Method |  Count |         Mean |      Error |     StdDev | Ratio | RatioSD |     Gen0 |     Gen1 | Allocated | Alloc Ratio |
|-------- |------- |-------------:|-----------:|-----------:|------:|--------:|---------:|---------:|----------:|------------:|
| **Decimal** |    **500** |     **1.543 μs** |  **0.0253 μs** |  **0.0224 μs** |  **1.00** |    **0.00** |        **-** |        **-** |         **-** |          **NA** |
|   Union |    500 |     5.061 μs |  0.0200 μs |  0.0177 μs |  3.28 |    0.05 |        - |        - |         - |          NA |
|     Box |    500 |     3.836 μs |  0.0627 μs |  0.0586 μs |  2.48 |    0.06 |   1.9073 |   0.0534 |   16000 B |          NA |
|         |        |              |            |            |       |         |          |          |           |             |
| **Decimal** | **100000** |   **436.853 μs** |  **1.2877 μs** |  **1.1416 μs** |  **1.00** |    **0.00** |        **-** |        **-** |         **-** |          **NA** |
|   Union | 100000 | 1,031.830 μs |  6.6980 μs |  5.2294 μs |  2.36 |    0.01 |        - |        - |       1 B |          NA |
|     Box | 100000 | 1,225.735 μs | 17.0834 μs | 15.9799 μs |  2.81 |    0.04 | 380.8594 | 171.8750 | 3200001 B |          NA |
