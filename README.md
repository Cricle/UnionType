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

### implicit cast in any time

```csharp
using System;
using UnionType;

internal class Program
{
    static void Main()
    {
        UnionValue a = 123;
        int b = a;//123
    }
}
```

### You can use navite point or ref 

```csharp
using System;
using UnionType;

internal class Program
{
    unsafe static void Main()
    {
        UnionValue a = 123;
        Console.WriteLine(*a.ToPointer<int>());//Print 123
    }
}
```

### It is not a read-only type

```csharp
using System;
using UnionType;

internal class Program
{
    static void Main()
    {
        var uv = (UnionValue)123;
        Inc(ref uv);
        Console.WriteLine(uv.@int);//Print 124
    }
    private static void Inc(ref UnionValue value)
    {
        value.@int++;
    }
}
```

### It can accommodate all basic types

- `void`(Empty)
- `byte`
- `sbyte`
- `bool`
- `char`
- `short`
- `ushort`
- `int`
- `uint`
- `long`
- `ulong`
- `float`(Single)
- `double`
- `decimal`
- `object`
- `DBNull`
- `DateTime`
- `String`
- `TimeSpan`(Additional types)
- `Guid`(Additional types)
- `IntPtr`(Additional types)

### It can fast alloc decimal from number

> Performace is alloc decimal benchmark

```csharp
using System;
using UnionType;

internal class Program
{
    static void Main()
    {
        var uv = UnionValue.FromAsDecimal(123);
        Console.WriteLine(uv.@decimal);//123
    }
}
```

### Implement p type interface(No .NET 7)

- ICloneable
- IComparable
- IConvertible
- IFormattable

### Space saving

```csharp
using System;
using System.Runtime.CompilerServices;
using UnionType;

internal class Program
{
    static void Main()
    {
        Console.WriteLine(Unsafe.SizeOf<UnionValue>());//In .NET7.0 print 24, other print 17
    }
}
```

### Able to operate

```csharp
using System;
using UnionType;

internal class Program
{
    static void Main()
    {
        UnionValue a = 123;
        UnionValue b = 456;

        var result = a + b;
        Console.WriteLine(result.ToString());//579
    }
}
```

Supports

- `+`
- `-`
- `*`
- `/`
- `%`

> Integer will become long, floating point will become decimal

### Can compare

```csharp
using System;
using UnionType;

internal class Program
{
    static void Main()
    {
        UnionValue a = 123;
        var b = 456;
        Console.WriteLine(a > b);//False
        Console.WriteLine(a < b);//True
    }
}
```

Supports

- `>`
- `>=`
- `<`
- `<=`
- `==` It will check type
- `!=` It will check type

### Can store object(weak ref)

```csharp
using System;
using UnionType;

internal class Program
{
    static void Main()
    {
        var obj = new Program();
        var uv = new UnionValue { Object = obj };
        Console.WriteLine(uv.TypeNameString);//Program, rsa2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
        Console.WriteLine(uv.Object);//Program
    }
}
```

### No box, raw type, can box if you need

```csharp
using System;
using UnionType;

internal class Program
{
    static void Main()
    {
        var uv = UnionValue.FromAsDecimal(123);
        Console.WriteLine(uv.Box());//123
    }
}
```

### FromObject or raw type

```csharp
using System;
using UnionType;

internal class Program
{
    static void Main()
    {
        var uv = UnionValue.FromObject(123);//Fast
        Console.WriteLine(uv.Box());//123
        uv = UnionValue.FromObject((object)123);
        Console.WriteLine(uv.Box());//123
    }
}
```

>I use raw point copy!

https://github.com/Cricle/UnionType/blob/eff150cb9a216506ea8d6b3968101165251e431b/src/UnionType/UnionValueCreator.cs#L108

In serialize case.(Can see `UnionValueToBytesHelperTest.cs`)

# Performace

``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19045.2364)
Intel Core i5-9400F CPU 2.90GHz (Coffee Lake), 1 CPU, 6 logical and 6 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


```
|     Method |   Count |           Mean |        Error |      StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|----------- |-------- |---------------:|-------------:|------------:|------:|--------:|----------:|------------:|
|    **Decimal** |     **500** |       **136.3 ns** |      **0.37 ns** |     **0.33 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
|      Union |     500 |       136.5 ns |      0.47 ns |     0.42 ns |  1.00 |    0.00 |         - |          NA |
|        Box |     500 |       136.5 ns |      0.66 ns |     0.62 ns |  1.00 |    0.00 |         - |          NA |
| BigInteger |     500 |       912.7 ns |      3.84 ns |     3.59 ns |  6.70 |    0.03 |         - |          NA |
|            |         |                |              |             |       |         |           |             |
|    **Decimal** | **5000000** | **1,290,235.7 ns** |  **2,928.91 ns** | **2,596.40 ns** |  **1.00** |    **0.00** |         **-** |          **NA** |
|      Union | 5000000 | 1,291,152.6 ns |  4,300.97 ns | 3,812.70 ns |  1.00 |    0.00 |       1 B |          NA |
|        Box | 5000000 | 1,291,088.1 ns |  3,581.48 ns | 2,990.70 ns |  1.00 |    0.00 |       1 B |          NA |
| BigInteger | 5000000 | 9,026,300.8 ns | 10,061.51 ns | 8,919.27 ns |  7.00 |    0.01 |       8 B |          NA |
