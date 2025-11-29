using BenchmarkDotNet.Attributes;

namespace ConsoleApp2
{
    [MemoryDiagnoser]
    public class HexBenchmark
    {

        private string testInput = "7bA3c529";

        [Benchmark]
        public int v1() => V1.ConvertHexToDec(testInput);

        [Benchmark]
        public int v2() => V2.ConvertHexToDec(testInput);

        [Benchmark]
        public int v3() => V3.ConvertHexToDec(testInput);

        [Benchmark]
        public int v4() => V4.ConvertHexToDec(testInput);

        [Benchmark]
        public int v5() => V5.ConvertHexToDec(testInput);

        [Benchmark]
        public int v6() => V6.ConvertHexToDec(testInput);

        [Benchmark]
        public int v7() => V7.ConvertHexToDec(testInput);

        [Benchmark]
        public int v8() => V8.ConvertHexToDec(testInput);

        [Benchmark]
        public int v9() => V9.ConvertHexToDec(testInput);

        [Benchmark]
        public int v10() => V10.ConvertHexToDec(testInput);

        [Benchmark]
        public bool v11() => V11.TryConvertHexToDec(testInput, out _);

        [Benchmark]
        public bool v12() => V12.TryConvertHexToDec(testInput, out _);

    }
}
