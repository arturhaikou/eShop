# eShop Ordering.Infrastructure: Architecture & Codebase Report

## Title
**eShop/src/Ordering.Infrastructure** – Implements persistence, data access, and infrastructure logic for the Ordering domain in the eShop distributed system.

## Summary
- Provides Entity Framework Core integration, migrations, and repository implementations for order management.
- Supports idempotency, request management, and entity configuration for robust order processing.
- Implements repository and data access patterns for buyers, orders, and related entities.
- Integrates with the broader eShop solution for distributed event-driven workflows.
- Uses .NET 10, EF Core, and follows modern DI and configuration conventions.

## Projects & Folder Map
| Folder/File | Purpose |
|-------------|---------|
| `Ordering.Infrastructure.csproj` | Project file, defines dependencies and build settings |
| `OrderingContext.cs` | EF Core DbContext for order domain entities |
| `EntityConfigurations/` | Fluent API configurations for EF Core entities |
| `Idempotency/` | Implements idempotent request handling (request manager, client request) |
| `Migrations/` | EF Core migrations for schema evolution |
| `Repositories/` | Repository implementations for Buyer and Order aggregates |
| `MediatorExtension.cs` | Extension for mediator pattern integration |
| `GlobalUsings.cs` | Global using directives for project-wide scope |

## Component Diagram
```mermaid
graph TD
    subgraph Ordering.API
        OA[OrderingContext (EF Core)]
        OR[OrderRepository]
        BR[BuyerRepository]
        RM[RequestManager]
    end
    DB[(SQL Database)]
    OA -- EF Core --> DB
    OR -- Uses --> OA
    BR -- Uses --> OA
    RM -- Uses --> OA
```

ASCII fallback:
Ordering.API
  |-- OrderingContext (EF Core) --> SQL Database
  |-- OrderRepository --> OrderingContext
  |-- BuyerRepository --> OrderingContext
  |-- RequestManager --> OrderingContext

## Communication Channels
- **Database:**
  - SQL Server (via EF Core)
  - Connection configured in Ordering.API/appsettings.json (not in this project)
- **Internal API:**
  - No direct HTTP/gRPC endpoints in Infrastructure; exposed via Ordering.API
- **Messaging/Eventing:**
  - Idempotency and request management support event-driven workflows

## Data Flow
### 1. Place Order
1. API receives order request (`Ordering.API/Controllers/OrderController.cs`)
2. Validates and maps to domain model
3. Persists via `OrderRepository` (`Repositories/OrderRepository.cs`)
4. Saves changes in `OrderingContext` (`OrderingContext.cs`)
5. Publishes integration event (handled outside Infrastructure)

### 2. Idempotent Request Handling
1. Incoming request checked for idempotency (`Idempotency/RequestManager.cs`)
2. If not processed, executes business logic
3. Records request in `ClientRequest` entity
4. Persists via `OrderingContext`

## Dependency Registration & DI Wiring
- **DI Container:** Microsoft.Extensions.DependencyInjection
- **Registration Location:** Typically in `Ordering.API/Program.cs` (not in this project)
- **Example Registration:**
```csharp
// ...existing code...
services.AddScoped<IOrderRepository, OrderRepository>();
services.AddScoped<IBuyerRepository, BuyerRepository>();
services.AddScoped<IRequestManager, RequestManager>();
// ...existing code...
```

## Configuration & Secrets
- **Configuration Sources:**
  - No direct config in Infrastructure; expects connection strings and settings from consuming API (`Ordering.API/appsettings.json`)
- **Sensitive Data:**
  - No hard-coded secrets; uses DI and config from host
- **Migrations:**
  - Managed via EF Core tools and connection string in host

## Persistence & Data Access
- **ORM:** Entity Framework Core
- **DbContext:** `OrderingContext.cs`
- **Migrations:** `Migrations/` folder (e.g., `20230925222426_Initial.cs`)
- **Repositories:**
  - `Repositories/OrderRepository.cs`
  - `Repositories/BuyerRepository.cs`
- **Entity Configurations:**
  - `EntityConfigurations/OrderEntityTypeConfiguration.cs`, etc.

## Patterns & Architecture Notes
- **Repository Pattern:** Buyer and Order repositories
- **Idempotency Pattern:** RequestManager and ClientRequest
- **Event-driven Support:** Outbox migration, integration event support
- **EF Core Fluent Config:** EntityConfigurations folder
- **Separation of Concerns:** Infrastructure layer isolated from API and domain logic

## Security & Operational Considerations
- **Authentication/Authorization:** Not handled in Infrastructure; managed by API layer
- **Observability:** No direct logging/metrics; expects host to provide
- **Operational Risks:**
  - No hard-coded secrets
  - Migrations managed via EF Core
- **Deployment:**
  - No Dockerfile or manifest in this project; handled by host/API

---

This report documents the architecture and codebase of `Ordering.Infrastructure` as part of the eShop distributed system. For further details, see related API and domain projects.
