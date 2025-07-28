# Hybrid ORM for High-Performance .NET Applications

## Overview

HybridORM is a runtime-adaptive ORM architecture for .NET that combines the abstraction and maintainability of Entity Framework Core with the raw performance of RepoDb. It dynamically switches between the two based on query complexity and performance demands.

This repository supports reproducible benchmarking and integration into high-throughput enterprise applications.

> 📘 This work has been submitted for peer review at JOSS.

## Project Structure

```
.
├── src/                       # Source code and integration example
│   └── Project/
│       └── hamafinancialmiddleware-main/   # Real-world middleware system
├── docs/                      # Documentation and references
├── benchmarks/                # BenchmarkDotNet test projects
├── paper.md                   # JOSS-formatted paper
├── paper.bib                  # BibTeX citations
└── README.md
```

## Real-World Example

This repository includes a fully working .NET solution based on the proposed Hybrid ORM architecture:
[`hamafinancialmiddleware-main`](./src/Project/hamafinancialmiddleware-main)

This production-grade middleware system demonstrates how HybridORM principles are applied in real business domains such as:

- Financial transaction logging
- Layered service architecture
- RepoDb + EF Core hybrid integration
- Background services and API interactions
- Socket server and multi-service orchestration

**Structure:**

```
hamafinancialmiddleware-main/
├── Hama.Core/
├── Hama.Infrastructure/
├── Hama.Service/
├── Hama.SocketServer/
├── WinApp/
└── HamaFinancialMiddleware.sln
```

This example can be explored to understand how the hybrid data access strategy fits into modular, scalable software systems.

## Usage

To build and run:
```bash
dotnet build
dotnet run
```

The repository targets .NET 6 and .NET 8.

## License

MIT
