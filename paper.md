
---
title: 'Designing a Hybrid ORM Architecture for High-Performance and Maintainable .NET Applications'
tags:
  - .NET
  - ORM
  - Entity Framework
  - RepoDb
  - Architecture
  - High-performance
authors:
  - name: Mehrdad Azimi
    orcid: 0000-0000-0000-0000
    affiliation: 1
affiliations:
  - name: Independent Software Developer
    index: 1
date: 2024-05-20
---

# Summary

Modern .NET applications often face a trade-off between maintainability and raw performance when choosing object-relational mapping (ORM) strategies. Entity Framework Core (EF Core) offers rich abstraction and developer productivity, but struggles under high-throughput scenarios. Conversely, micro-ORMs like RepoDb or Dapper provide high-speed data access but sacrifice abstraction and maintainability. This paper presents a hybrid ORM architecture that integrates both EF Core and RepoDb, enabling runtime-based routing of database operations.

The hybrid approach intelligently delegates high-volume read/write operations to RepoDb while retaining EF Core’s advantages for complex queries and relational integrity. We implement a dual-repository structure with dynamic resolution via dependency injection and evaluate its performance across common scenarios. Benchmarks show up to 3.5× improvement in bulk insert speed and 4× faster lookups, without losing developer ergonomics. A production-grade financial logging microservice further demonstrates the architectural impact: a 38% reduction in CPU usage and 65% improvement in query performance. This architecture provides a viable template for scalable, maintainable, and high-performing data access strategies in enterprise .NET systems.

# Statement of Need

Object-relational mapping (ORM) is essential in modern software engineering but has historically been polarized between high-abstraction/low-performance solutions (e.g., EF Core) and high-performance/low-maintainability tools (e.g., RepoDb, Dapper). Current ORM systems in .NET do not offer runtime hybrid solutions that adjust to workload characteristics. This paper proposes and implements a fully functional hybrid ORM architecture to fill this critical gap.

The hybrid architecture dynamically selects between EF Core and RepoDb based on query complexity, volume, and type. This enables performance-critical paths to benefit from direct SQL execution while preserving LINQ and abstraction where necessary. It is the first system in .NET to implement and validate runtime hybrid ORM behavior with real-world workloads and benchmarks.

# Implementation and Benchmark Results

The proposed system is implemented using a RepositoryResolver class that dynamically chooses between EfRepository<T> and RepoDbRepository<T>. The hybrid approach routes bulk and simple queries to RepoDb, while complex LINQ joins are handled by EF Core.

Benchmarks were conducted on PostgreSQL using 10,000 record operations. The hybrid approach matched RepoDb's performance for inserts (940ms) and lookups (4ms) while outperforming EF Core significantly. A production-grade logging system showed a 38% CPU reduction and 65% improvement in report latency during peak loads.

# Software and Architecture

- Language: C#
- Framework: .NET 6 and 8 compatible
- Architecture: Repository pattern with runtime resolver
- Tools used: BenchmarkDotNet, MemoryProfiler
- Integration: EF Core and RepoDb via DI container
- Example case: Financial transaction logger (1000+ TPS) with auditing

# Acknowledgements

None.

# References
