# Architecture Overview

CoverageProject follows Clean Architecture principles.

## Layer Structure

API
    ↓
Application
    ↓
Domain (Core)
    ↓
Infrastructure

### Domain (Core)
Contains:
- Entities
- Value Objects
- Business Rules
- Domain Events (future)

This layer has ZERO dependencies.

---

### Application Layer
Contains:
- CQRS handlers
- Service interfaces
- DTOs
- Business orchestration logic

Depends only on Domain.

---

### Infrastructure Layer
Contains:
- EF Core
- Database implementation
- External services
- Repository implementations

Depends on Application + Domain.

---

### API Layer
Thin HTTP layer.
Contains:
- Controllers
- Dependency Injection
- Middleware

No business logic.
