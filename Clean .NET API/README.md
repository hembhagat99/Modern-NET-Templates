# 🚀 Clean .NET API Template `C#`

The **Clean .NET API Template** is your go-to solution for kickstarting robust and scalable .NET API projects while embracing the principles of Clean Architecture. This template offers a thoughtfully structured project layout emphasizing **maintainability**, **separation of concerns**, and **testability**. Whether you're a Clean Architecture newbie or a seasoned developer, this template simplifies project setup like a pro! 💻✨

The template generates a complete API Project with adherence to Clean Architecture principles, ensuring a **clear separation of layers**. Here's what it creates:  
- **🌟 Domain Layer**: Core business entities.  
- **🧠 Business Layer**: Use cases and business logic.  
- **🛠️ Infrastructure Layer**: Database and external integrations.  
- **🌐 API Layer**: API controllers.

## ⚡ Features

### 1️⃣ Authentication with Identity Framework
This template pre-configures the Identity Framework with EF Core and maps Identity API Endpoints, enabling you to secure your APIs effortlessly. Explore more about [Identity API Endpoints](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity-api-authorization?view=aspnetcore-8.0#the-mapidentityapituser-endpoints).

### 2️⃣ Repository Pattern with EF Core 
Includes a **BaseRepository**, a generic repository containing methods for CRUD operations on data models using EF Core. Easily extend this abstract repository for your models and implement the **Repository Pattern** seamlessly.  

> **💡 Note:** The template uses MySQL Database Provider for EF Core by default. You can switch to any EF Core-supported database provider.

### 3️⃣ Transaction Filter
Ensure atomic operations with the built-in **Transaction Filter**, guaranteeing **data integrity** for POST, PUT, and DELETE APIs.

### 4️⃣ Model Validation with FluentValidation
Validate your models effortlessly with pre-configured **FluentValidation**.  
- Includes a **ValidationFilter** to simplify model validation without redundant calls in every action method.  
- Supports **async validation** and includes custom validators for less repetitive configuration.

### 5️⃣ Exception Middleware
No more sprinkling `try-catch` everywhere! The template includes **Exception Middleware** to centralize exception handling and keep your codebase clean and elegant.

### 6️⃣ Automatic Database Migration (Development Mode)
Run your project in development mode, and any pending database migrations are applied automatically.  

> **⚠️ Note:** For production environments, avoid automatic migrations. Instead, apply them manually using [these methods](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/applying?tabs=dotnet-core-cli).

### 7️⃣ Automapper for Object Mapping
The template integrates **Automapper** to simplify and streamline object mapping, reducing boilerplate code.  

### 8️⃣ Standard Coding Practices
The codebase adheres to best practices:  
- Readable naming conventions.  
- Minimized code repetition.  
- Proper separation of concerns and abstractions.  

This fosters **readability**, **maintainability**, and **scalability**, inspiring users to follow the same high standards! 🏆 

## 🛠️ Getting Started

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) 8.0
- Visual Studio 2022
- Up & Running MySQL Database

### Installation
1. Download the [Modern .NET Templates](https://marketplace.visualstudio.com/items?itemName=hem-bhagat.ModernNETTemplates) extension from the Visual Studio Marketplace.
2. Search for the template by name: `Clean .NET API` in the new project dialog.
3. Follow the wizard to create your project.

> **⚠️ NOTE:** Project name should not contain white-space characters.

### Running the project

1. **Database Configuration**:
Update the connection string in `appsettings.Development.json` to match your MySQL database.

2. **Run the Application**:
Use Visual Studio or the .NET CLI to build and run the project. The application will apply migrations automatically (in development mode).
