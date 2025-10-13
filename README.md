# MicroLibraryAPI

A small REST API built in C#/.NET for managing a library of books and users.  
Uses Entity Framework Core with PostgreSQL for persistence.

## Features
- CRUD operations for Books and Users
- CamelCase PostgreSQL schema with PascalCase C# models
- Swagger UI for API testing
- Async EF Core operations

## Tech Stack
- Language: C# (.NET 8)
- Framework: ASP.NET Core Web API
- ORM: Entity Framework Core (EF Core)
- Database: PostgreSQL
- Documentation: Swagger / Swashbuckle
- Containerization: Docker (planned)
- IDE: Visual Studio Code on macOS

## Endpoints
### Books
- `GET /api/book` — list all books  
- `GET /api/book/{id}` — get a single book  
- `POST /api/book` — add a new book  
- `PUT /api/book/{id}` — update a book  
- `DELETE /api/book/{id}` — delete a book  

### Users
- `GET /api/user` — list users  
- `POST /api/user` — create user  
- `PUT /api/user/{id}` — update email  
- `DELETE /api/user/{id}` — delete user 
