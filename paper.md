---
title: 'Designing a Hybrid ORM Architecture for High-Performance .NET Applications'
tags:
  - dotnet
  - ORM
  - EFCore
  - RepoDb
  - architecture
authors:
  - name: "Mehrdad Azimi"
    orcid: 0000-0003-9751-3952
    affiliation: 1
affiliations:
  - name: AzimiDeveloper
    index: 1
date: 2025-05-20
---

# Summary

This paper introduces a hybrid ORM architecture that combines the flexibility of EF Core and the performance of RepoDb to optimize real-world .NET applications.

# Statement of need

.NET developers often struggle with balancing advanced querying capabilities and performance. This hybrid model addresses that by using EF Core for complex data relationships and RepoDb for high-throughput operations.

# Implementation

The architecture separates concerns using two repository classes:
- `EfBaseRepository<TEntity>` using EF Core
- `RepoDbBaseRepository<TEntity>` using RepoDb

# Performance

Benchmark results show significantly improved response time and reduced memory usage using this hybrid model.

# References

- Entity Framework Core Documentation
- RepoDb Documentation
