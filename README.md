# Hybrid ORM for High-Performance .NET Applications

[![JOSS](https://joss.theoj.org/papers/eaef6f46ebc9ed94cd239c183b9509db/status.svg)](https://joss.theoj.org/papers/eaef6f46ebc9ed94cd239c183b9509db)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

## 🔍 Overview

**HybridORM** is a runtime-adaptive ORM architecture for .NET that combines the high-performance of micro-ORMs like [RepoDb](https://repodb.net) with the abstraction and flexibility of [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/).

This architecture intelligently routes data access operations between EF Core and RepoDb based on query complexity and performance needs — allowing you to enjoy the best of both worlds without rewriting your business logic.

> 📘 This project is accompanied by a [peer-reviewed scientific paper](https://github.com/openjournals/joss-reviews/issues/8254) submitted to the [Journal of Open Source Software (JOSS)](https://joss.theoj.org/).

## 🚀 Key Features

- ✅ **Dual-ORM Support**: EF Core for complex queries, RepoDb for high-throughput access
- ⚡ **3.5× faster** bulk insert & **4× faster** lookups (benchmarked vs EF Core)
- 🧠 **Smart Routing**: Operation type, query complexity, and payload size determine the optimal ORM
- ♻️ **Pluggable** via Dependency Injection
- 🧪 **Production-tested** in financial transaction microservices with >1000 TPS

## 📐 Architecture

```
+--------------------+
|  Application Layer |
+--------------------+
          ↓
+-----------------------------+
|     RepositoryResolver<T>   |  ← decides dynamically
+-----------------------------+
        ↙           ↘
+----------------+  +---------------------+
| EFRepository<T>|  | RepoDbRepository<T> |
+----------------+  +---------------------+
        ↓                  ↓
     EF Core           RepoDb
```

## 📦 Installation

Clone the repository and add the services to your DI container:

```bash
git clone https://github.com/AzimiDeveloper/HybridORM.git
```

Register hybrid repositories in your `Startup.cs` or `Program.cs`:

```csharp
services.AddScoped(typeof(IRepository<>), typeof(RepositoryResolver<>));
```

## 🧪 Benchmark Results

| Operation            | EF Core | RepoDb | Hybrid |
|----------------------|--------:|-------:|-------:|
| Bulk Insert (10k)    | 3250 ms | 940 ms | 940 ms |
| Single Lookup        | 18 ms   | 4 ms   | 4 ms   |
| One-to-Many Join     | 780 ms  | 620 ms | 620 ms |

> Benchmarked using BenchmarkDotNet on PostgreSQL 13.3 with .NET 8

## 🏦 Real-World Case Study

Deployed in a payment logging microservice at production scale:
- **>1000 Transactions per second**
- **38% reduction in peak CPU usage**
- **65% improvement in reporting latency**

## 📄 Scientific Publication

This repository accompanies the following peer-reviewed paper:

📘 **Designing a Hybrid ORM Architecture for High-Performance and Maintainable .NET Applications**  
✍️ *Mehrdad Azimi*  
📎 [paper.md](./paper.md) | [paper.bib](./paper.bib)  
📚 [JOSS Review Issue #8254](https://github.com/openjournals/joss-reviews/issues/8254)

## 📂 Folder Structure

```
.
├── /src                # Main hybrid ORM implementation
├── /examples           # Sample usage and integration code
├── /benchmarks         # BenchmarkDotNet projects
├── paper.md            # JOSS scientific paper
├── paper.bib           # References
└── README.md
```

## 📜 License

This project is licensed under the [MIT License](LICENSE).

## 🤝 Contributions

Pull requests and feedback are welcome!  
Please open an issue to discuss significant changes or ideas before contributing.
