using BenchmarkDotNet.Attributes;

namespace Depra.Common.Extensions.Benchmarks
{
    [MemoryDiagnoser]
    public class IsNumericBenchmarks
    {
        private readonly int _intValue = 1;
        private readonly long? _nullableLongValue = int.MaxValue;

        private object ObjIntValue => _intValue;

        [Benchmark(Baseline = true)]
        public bool IsNumeric() => _intValue.IsNumeric();

        [Benchmark]
        public void IsNumericAtRuntime() => ObjIntValue.IsNumericAtRuntime();

        [Benchmark]
        public void IsNullableNumeric() => _nullableLongValue.IsNullableNumeric();
    }
}