# Hybrid ORM for High-Performance .NET Applications

## Overview

HybridORM is a runtime-adaptive ORM architecture for .NET that combines the abstraction and maintainability of Entity Framework Core with the raw performance of RepoDb. It dynamically switches between the two based on query complexity and performance demands.

This repository supports reproducible benchmarking and integration into high-throughput enterprise applications.

> 📘 This work has been submitted for peer review at JOSS.

## Project Structure

```
.
├── src/                 # C# source code (fully documented in English)
├── docs/                # Documentation and references
├── benchmarks/          # BenchmarkDotNet test projects
├── paper.md             # JOSS-formatted paper
├── paper.bib            # BibTeX citations
└── README.md
```

## Usage

To build and run:
```bash
dotnet build
dotnet run
```

The repository targets .NET 6 and .NET 8.

## License

MIT
