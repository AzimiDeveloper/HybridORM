# Hybrid ORM Architecture (.NET)

[![JOSS Submission](https://joss.theoj.org/papers/eaef6f46ebc9ed94cd239c183b9509db/status.svg)](https://joss.theoj.org/papers/eaef6f46ebc9ed94cd239c183b9509db)

This project implements a **Hybrid ORM Architecture** for .NET applications by combining the flexibility of **Entity Framework Core** with the high performance of **RepoDb**. It was developed with real-world .NET systems in mind, where balancing complexity and speed is essential.

## 🔧 Features

- Dual-ORM support via clean abstraction
- `EfBaseRepository<TEntity>` for complex querying & relations
- `RepoDbBaseRepository<TEntity>` for lightweight CRUD operations
- Performance benchmarking
- Clean, testable, modular architecture
- Fully documented with JOSS-compatible submission

## 📦 Structure

```
/HybridORM
├── src/
│   ├── Repositories/
│   └── Models/
├── paper.md
├── README.md
├── LICENSE
└── .github/workflows/paper.yml
```

## 🚀 Getting Started

Clone this repository:
```bash
git clone https://github.com/AzimiDeveloper/HybridORM.git
```

To use the hybrid architecture in your .NET project, reference the repository classes under `src/Repositories/`.

## 📄 Documentation

For full architecture details, see [`paper.md`](paper.md) or the JOSS page:
🔗 https://joss.theoj.org/papers/eaef6f46ebc9ed94cd239c183b9509db

## 🛠️ Build & Compile

This project uses GitHub Actions to automatically compile the `paper.md` using the JOSS Action.

## 🧪 Testing

This version does not yet include unit tests. Testable components are designed to support both EF Core and RepoDb operations.

## 📃 License

This project is licensed under the [MIT License](LICENSE).

## 👤 Author

**Mehrdad Azimi**  
ORCID: [0000-0003-9751-3952](https://orcid.org/0000-0003-9751-3952)

---

This project was submitted to the [Journal of Open Source Software (JOSS)](https://joss.theoj.org) for peer review.
