# ternary_op_vs_lookup_table_bench
Ternary Operator vs Lookup Table Benchmark

I discovered a real case of premature micro-optimization when you don't measure. You know it is pretty bad when you read premature and micro on the same sentence. On the page 44 of [Optimizing C++](https://www.agner.org/optimize/optimizing_cpp.pdf) ebook by Agner Fog, it is written ...

*In some cases it is possible to replace a poorly predictable branch by a table lookup. For example:*

``` 
float a;
bool b;
a = b ? 1.5f : 2.6f;
```
 
*The ?: operator here is a branch. If it is poorly predictable then replace it by a table lookup:*
 
```
float a;
bool b = 0;
const float lookup[2] = {2.6f, 1.5f};
a = lookup[b];
```
 
*If a bool is used as an array index then it is important to make sure it is initialized or comes from a reliable source so that it can have no other values than 0 or 1. In some cases the compiler can automatically replace a branch by a **conditional move**.*

I was trying to implement this lookup table optimization (to replace ternary operator) on a floating-point value which the code is compiled with G++ and ran on Linux. I also ran the integer benchmark and on other compilers such like Visual C++ 2019 and Clang and also the Visual C# 7 to see their differences. In C++ benchmark, the lookup array is declared as a static local variable inside the function. In Visual C# code, static local variable is not permitted so the lookup array is declared as a static member variable inside the function. This is the benchmark results below.

```
VC++ /Ox results
       IntTernaryOp:  562ms, result:3500000000
         IntArrayOp:  523ms, result:3500000000
     FloatTernaryOp: 3972ms, result:3.5e+09
       FloatArrayOp: 1030ms, result:3.5e+09
G++ 7.4.0 -O3 results
       IntTernaryOp:  306ms, result:3500000000
         IntArrayOp:  519ms, result:3500000000
     FloatTernaryOp: 1030ms, result:3.5e+09
       FloatArrayOp: 1030ms, result:3.5e+09
Clang++ 6.0.0 -O# results
       IntTernaryOp:  585ms, result:3500000000
         IntArrayOp:  523ms, result:3500000000
     FloatTernaryOp: 1030ms, result:3.5e+09
       FloatArrayOp: 1030ms, result:3.5e+09
C# 7 Release Mode, .NET Framework 4.7.2
       IntTernaryOp: 1311ms, result:3500000000
         IntArrayOp: 1038ms, result:3500000000
     FloatTernaryOp: 2448ms, result:3500000000
       FloatArrayOp: 1036ms, result:3500000000
```

