using BenchmarkDotNet.Attributes;
using Lingua;

namespace Bench
{
    public class Bencher
    {
        const string Input = "Hello, world!";

        private readonly Detector lingua;

        public Bencher()
        {
            lingua = new Detector();
        }

        [Benchmark]
        public int Lingua() => lingua.DetectLanguage(Input);
    }
}
