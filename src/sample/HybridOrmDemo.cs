
using Hama.Infrastructure.Repositories;
using Hama.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore;
using RepoDb;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HybridOrmDemo
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class Demo
    {
        private readonly IBaseEfRepository<Product> _efRepository;
        private readonly IBaseRepoDbRepository<Product> _repoDbRepository;

        public Demo(IBaseEfRepository<Product> efRepo, IBaseRepoDbRepository<Product> repoDbRepo)
        {
            _efRepository = efRepo;
            _repoDbRepository = repoDbRepo;
        }

        public async Task RunAsync()
        {
            Console.WriteLine("🔹 EF Core - Insert");
            await _efRepository.InsertAsync(new Product { Name = "Laptop", Price = 1000 });
            await _efRepository.SaveAsync();

            Console.WriteLine("🔹 RepoDb - Insert");
            await _repoDbRepository.InsertAsync(new Product { Name = "Phone", Price = 500 });

            Console.WriteLine("🔹 EF Core - Read");
            var efProducts = await _efRepository.GetAsync();
            foreach (var p in efProducts)
                Console.WriteLine($"EF Product: {p.Name} - {p.Price}");

            Console.WriteLine("🔹 RepoDb - Read");
            var repoDbProducts = await _repoDbRepository.GetAsync();
            foreach (var p in repoDbProducts)
                Console.WriteLine($"RepoDb Product: {p.Name} - {p.Price}");
        }
    }
}
