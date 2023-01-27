using BenchmarkDotNet.Attributes;
using Depra.Common.Extensions;

namespace Depra.Common.Benchmarks.Extensions;

public class IsNumericBenchmarks
{
    private readonly int _intValue = 1;
    private readonly long? _nullableLongValue = int.MaxValue;

    private object ObjIntValue => _intValue;

    [Benchmark(Baseline = true)]
    public bool IsNumeric() => 
        _intValue.IsNumeric();

    [Benchmark]
    public void IsNumericAtRuntime() =>
        ObjIntValue.IsNumericAtRuntime();

    [Benchmark]
    public void IsNullableNumeric() => 
        _nullableLongValue.IsNullableNumeric();
}