
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Collections.Generic;
using System.Linq;

namespace HybridORM.Benchmarks
{
    [MemoryDiagnoser]
    public class OrmBenchmarks
    {
        private List<int> data;

        [GlobalSetup]
        public void Setup()
        {
            data = Enumerable.Range(1, 10000).ToList();
        }

        [Benchmark]
        public void EfCoreSimulation()
        {
            var sum = data.Where(x => x % 2 == 0).Sum();
        }

        [Benchmark]
        public void RepoDbSimulation()
        {
            int sum = 0;
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i] % 2 == 0)
                    sum += data[i];
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<OrmBenchmarks>();
        }
    }
}
