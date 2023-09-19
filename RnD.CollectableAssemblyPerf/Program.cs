using BenchmarkDotNet.Running;

namespace RnD.CollectableAssemblyPerf;

internal class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<Test>();
    }
}