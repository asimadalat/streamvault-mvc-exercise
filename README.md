# StreamVault Catalogue Manager

An internal admin dashboard for StreamVault, where media such as movies, series, audiobooks or music albums can be added to the catalogue, edited or removed.

---

## How to run the application

### Prerequisites
* [.NET 10.0 SDK](https://dotnet.microsoft.com/en-us/download) installed on your system

### Steps to build and run
1. Open your terminal and navigate to the root directory containing the project file
2. Restore dependencies and build:
    ```bash
    dotnet build
    ```
3. Run the application:
    ```bash
    dotnet run
    ```
4. Open any web browser and navigate to the local URL shown in the terminal


## Database Creation and Seeding

The application uses a local SQLite instance generated on startup, StreamVault.db.

To ensure a deterministic testing experience for reviewers, the lifecycle is automated on startup via DbManager.

* `EnsureCreatedAndSeeded()`: Constructs the physical SQLite file and table schemas if they do not already exist, via inspecting the current EF context. Invokes `EnsureSeeded()`, which detects if the catalogue database is empty, and if so, injects a realistic sample dataset of 20 entities, spanning all content types.

## Key Design Decisions

### 1. Data Layer, Inheritance using Table-Per-Hierarchy (TPH)

Business requirements specify four distinct media formats, sharing some properties. Entity Framework's TPH structure was perfect to map the resulting inheritance tree, where four derived classes inherit their shared properties from the base `CatalogueItem` class, to a flat SQL table, using an internal `ContentType` discriminator.

* TPH was chosen over Table-Per-Type as while normalisation would prevent the number of nullable fields required, it also introduces heavy execution overhead to aggregate the data, compromising on database performance at scale.

* TPH translates the main view query to a single-scanning `SELECT * FROM CatalogueItems`, where no joins are required. NULL values carry zero storage overhead on the physical disk.

### 2. Mutations, Separated Endpoints

Instead of using a single polymorphic endpoint for mutations, four distinct strongly-typed `POST` endpoints are used, for borh Create and Edit operations.

* Avoids scattered `if/switch` branching inside the request pipeline

* ASP .NET Core's native model validation `ModelState.IsValid()` can execute for each unique metadata structure for strict validation per-type.

### Future Considerations

Given further development time, I would introduce these enhancements:

1. Confirmation of Successful Create/Edit/Delete Operations. An important UX consideration that will make the portal more usable day-to-day would be a toast or confirmation informing the user of a successful creation etc.

2. Sequential Guids (v7): Transition primary keys for `CatalogueItem` from standard `Guid` v4 to sequential v7. The embedded timestamp prefix will be vital in preventing index fragmentation at scale.

3. Server-Side Pagination: Use `.Skip(X).Take(Y)` limits to set a boundary on database memory consumption per request as catalogue scales to thousands of items.

4. GUID Storage Formats: Configure .NET `Guid` to map to compressed `binary(16)` as opposed to a string to optimise for disk space.

