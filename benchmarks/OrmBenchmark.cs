
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HybridORM.Benchmarks
{
    [MemoryDiagnoser]
    public class OrmBenchmarks
    {
        private List<DummyEntity> data;

        [GlobalSetup]
        public void Setup()
        {
            data = Enumerable.Range(1, 10000)
                .Select(i => new DummyEntity { Id = i, Name = $"Item {i}" })
                .ToList();
        }

        [Benchmark]
        public void SimulateEfCoreQuery()
        {
            // Simulates EF Core LINQ query with some overhead
            var result = data.Where(x => x.Id % 2 == 0)
                             .OrderBy(x => x.Name)
                             .ToList();
        }

        [Benchmark]
        public void SimulateRepoDbQuery()
        {
            // Simulates RepoDb direct mapping and lightweight filtering
            var result = new List<DummyEntity>();
            foreach (var item in data)
            {
                if (item.Id % 2 == 0)
                    result.Add(item);
            }

            result.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.Ordinal));
        }
    }

    public class DummyEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<OrmBenchmarks>();
        }
    }
}
