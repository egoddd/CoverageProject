![CI](https://github.com/egoddd/CoverageProject/actions/workflows/ci.yml/badge.svg)(https://github.com/egoddd/CoverageProject/actions/workflows/ci.yml)
![License](https://img.shields.io/github/license/egoddd/CoverageProject)
![Release](https://img.shields.io/github/v/release/egoddd/CoverageProject)
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

          ┌───────────────────────┐
          │        Coverage.API   │
          │  Controllers / HTTP   │
          └───────────▲───────────┘
                      │
          ┌───────────┴───────────┐
          │   Coverage.Application│
          │   Use Cases / Services│
          └───────────▲───────────┘
                      │
          ┌───────────┴───────────┐
          │      Coverage.Domain  │
          │  Entities / Rules     │
          └───────────────────────┘

          Infrastructure implements
          interfaces defined in Application

---

## 🏭 Production Architecture (Target)

CoverageProject is designed to evolve toward a distributed architecture capable of supporting high-scale financial workflows.


                         ┌──────────────────────────┐
                         │        Clients           │
                         │ Web / Mobile / Partners  │
                         └─────────────┬────────────┘
                                       │ HTTPS
                                       v
                         ┌──────────────────────────┐
                         │        Coverage.API      │
                         │ REST Endpoints           │
                         │ Auth • Validation        │
                         └─────────────┬────────────┘
                                       │
                                       v
                         ┌──────────────────────────┐
                         │   Coverage.Application   │
                         │ Use Cases / Commands     │
                         │ Business Workflows       │
                         └─────────────┬────────────┘
                                       │
                                       v
                         ┌──────────────────────────┐
                         │     Coverage.Domain      │
                         │ Entities / Rules         │
                         │ Domain Events            │
                         └─────────────┬────────────┘
                                       │
                                       v
                         ┌──────────────────────────┐
                         │  Coverage.Infrastructure │
                         │ Repositories / EF Core   │
                         │ External Services        │
                         └─────────────┬────────────┘
                                       │
                                       v
                         ┌──────────────────────────┐
                         │       SQL Server         │
                         │     Primary Storage      │
                         └─────────────┬────────────┘
                                       │
                                       v
                         ┌──────────────────────────┐
                         │    Message Broker        │
                         │   Async Event Pipeline   │
                         │ (RabbitMQ / Kafka later) │
                         └─────────────┬────────────┘
                                       │
                                       v
                         ┌──────────────────────────┐
                         │ Background Workers       │
                         │ Event Processing         │
                         │ Notifications / Jobs     │
                         └──────────────────────────┘

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

<bash>
dotnet restore
dotnet build
dotnet run

---

# 📚 Repository Index

This profile is organized around three engineering tracks.

## Distributed Systems Engineering

| Repository | Description |
|------------|-------------|
| [CoverageProject](https://github.com/egoddd/CoverageProject) | Clean Architecture insurance platform used as a distributed systems engineering lab |
| Distributed Systems Playbook | Architecture notes, patterns, and system design studies |

---

## Financial / Quant Infrastructure

| Repository | Description |
|------------|-------------|
| Quant Infrastructure Lab | Experiments in financial system infrastructure and event-driven workflows |
| Market Data Systems | Exploration of financial data pipelines and processing |

---

## Performance Engineering (.NET)

| Repository | Description |
|------------|-------------|
| DotNet Performance Lab | Experiments with concurrency, async systems, and performance optimization |
| Systems Algorithms | Algorithms and data structures relevant to high-performance systems |
