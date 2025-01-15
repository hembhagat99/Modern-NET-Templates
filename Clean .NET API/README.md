# Clean .NET API Template

The **Clean .NET API Template** is designed to help developers quickly start building robust and scalable .NET API projects by following the principles of Clean Architecture. This template provides a well-structured project layout with a focus on maintainability, separation of concerns, and testability. Whether you're new to Clean Architecture or an experienced developer, this template simplifies the process of setting up your project.

## Features

### 1. Complete API Project with Clean Architecture
- Generates a complete API project adhering to Clean Architecture principles.
- Ensures a clear separation of layers:
  - **Domain Layer** for core business entities.
  - **Business Layer** for use cases and business logic.
  - **Infrastructure Layer** for database and external integrations.
  - **Presentation Layer** for API controllers.

### 2. Smooth Database Integration with EF Core for MySQL
- Integrates seamlessly with **Entity Framework Core** for MySQL.
- Implements a **Generic Repository Pattern** to simplify database operations and reduce boilerplate code.
- The Database Provider can be quickly changed to work with other databases as well.

### 3. Model Validation with FluentValidation
- Includes **FluentValidation** for defining and enforcing model validation rules.
- Comes with a **Validation Filter**, eliminating the need to manually validate in each action method.

### 4. Built-in Authentication
- Provides authentication out of the box using the **Identity Framework**.
- Simplifies user management and security.

### 5. Transaction Filter for Atomic Operations
- Includes a **Transaction Filter** to ensure that database operations in POST, PUT, and DELETE APIs are atomic.
- Helps maintain data consistency in critical operations.

### 6. BaseController with Essential Filters
- A **BaseController** is included, pre-configured with essential filters like validation and transaction handling.
- Reduces repetitive code in individual controllers.

### 7. Automatic Migration on Startup
- Automatically applies database migrations at application startup when running in development mode.
- Simplifies the development process by keeping the database schema up-to-date.

### 8. Automapper for Simplifying Mapping Tasks
- Includes **Automapper** to streamline the process of mapping between objects, reducing repetitive and boilerplate code.

## Getting Started

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) 8.0
- Visual Studio 2022 or later
- Up & Running MySQL Database

### Installation
1. Download the extension from the [Visual Studio Marketplace](https://marketplace.visualstudio.com).
2. Search for the template by name: `Clean .NET API` in the new project dialog.
3. Follow the wizard to configure your project.

### CLI Usage
You can also use this template with the .NET CLI:

```bash
dotnet new clean-api-cs -n YourProjectName
```

## How to Use

1. **Database Configuration**:
   - Update the connection string in `appsettings.Development.json` to match your MySQL database.

2. **Run the Application**:
   - Use Visual Studio or the .NET CLI to build and run the project.
   - The application will apply migrations automatically (in development mode).
