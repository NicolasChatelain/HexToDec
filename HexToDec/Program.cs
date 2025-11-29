using BenchmarkDotNet.Running;
using ConsoleApp2;

internal class Program
{
    private static void Main(string[] args)
    {
        BenchmarkRunner.Run<HexBenchmark>();
    }
}