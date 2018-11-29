# Dashboard.Api
Dashboard storage and retrieval services.

##### Features:

- Custom ordering of dashboard definitions.
- Dashboard definitions contain:
  - A name and title.
  - An ordered collection of tiles.
  - A layout specification for tiles.
  - Data points (tags) for each tile.
  - A time frame for requesting tag data (future).

##### Implementation:

- ASP.NET Core Web API 2.1.
- Entity Framework Core.
- SQL Serve back-end.
- Repository pattern for testability.
- Swagger document support.
- CORS support.
- All async API's.