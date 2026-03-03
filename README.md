[![CI](https://github.com/egoddd/CoverageProject/actions/workflows/ci.yml/badge.svg)](https://github.com/egoddd/CoverageProject/actions/workflows/ci.yml)
# CoverageProject

Enterprise-grade insurance platform engineered as a distributed systems training ground.

This project is built to master Clean Architecture, Domain-Driven Design (DDD), CQRS, performance engineering, and financial system patterns.

---

## 🎯 Purpose

CoverageProject is not a tutorial project.

It is a long-term engineering vehicle designed to evolve into a distributed, event-driven, quant-grade financial system.

---

## 🏗 Architecture

This system follows strict Clean Architecture principles:

- Core (Domain models, entities, business rules)
- Application (Use cases, CQRS handlers)
- Infrastructure (Database, external integrations)
- API (Thin controllers)

Separation of concerns is enforced.

---

## 🧠 Engineering Focus

- Clean Architecture
- Domain-Driven Design
- CQRS
- Repository Pattern
- Async/Await
- Thread Safety
- Performance Optimization
- Observability (planned)
- Event-Driven Extensions (planned)

---

## 📊 Domain Modules

- Users
- Policies
- Claims
- Payments
- Decentralized Pools (planned)

---

## 🚀 How to Run

```bash
dotnet restore
dotnet build
dotnet run
