# Dashboard.Api
Dashboard storage and retrieval services.

##### Features:

- Custom ordering of dashboard definitions.
- Dashboard definitions contain:
  - A name.
  - An ordered collection of tiles.
  - A layout specification for tiles.
  - Data points (tags or documents) for each tile.
  - A time frame for requesting tile data.
  - An extensible property bag for all visual properties.

##### Implementation:

- ASP.NET Core Web API 2.2.
- Entity Framework Core.
- SQL Serve back-end.
- Repository pattern for testability.
- Swagger document support.
- CORS support.
- All async API's.