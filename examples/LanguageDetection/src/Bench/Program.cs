using BenchmarkDotNet.Running;

namespace Bench
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Bencher>();
        }
    }
}
