# ProjectAPI

ProjectAPI is an ASP.NET Core API that leverages various technologies to provide a robust and efficient solution. It includes features like EF Core for database interactions, AutoMapper for object mapping, PostgreSQL as the database, FluentValidation for input validation, and an xUnit test project for testing.

## Technologies Used

- ASP.NET Core
- Entity Framework Core (EF Core)
- AutoMapper
- PostgreSQL
- FluentValidation
- xUnit

## Getting Started

### Prerequisites

- .NET 8.0 ([Download .NET](https://dotnet.microsoft.com/download))
- PostgreSQL Database
- Visual Studio or Visual Studio Code (Optional)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/b3kz0d/project-api.git
   cd project-api/ProjectAPI

2. Build and run the application:

   ```bash
   dotnet build
   dotnet run

### Configuration

Update the appsettings.json and appsettings.test.json files with your PostgreSQL connection string.

   ```bash
   {
    "ConnectionStrings": {
        "ProjectDb": "Your PostgreSQL Connection String"
    },
    // Other configurations...
   }

