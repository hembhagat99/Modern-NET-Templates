# Modern .NET Templates

Welcome to the **Modern .NET Templates** repository! This is your one-stop destination for a collection of high-quality, ready-to-use templates for .NET projects. These templates are designed to help developers kickstart their projects with best practices, clean architecture principles, and pre-configured features.

Whether you are building APIs, web applications, or microservices, these templates are crafted to save you time and effort by providing a solid foundation.

## Available Templates

### 1. Clean Architecture API Template
- **Description**: A comprehensive template for building robust and scalable APIs using Clean Architecture principles.
- **Features**:
  - Fully configured project structure with Domain, Application, Infrastructure, and Presentation layers.
  - Built-in EF Core integration with MySQL.
  - Model validation using FluentValidation.
  - Authentication with Identity Framework.
  - Atomic database operations with a Transaction Filter.
  - Automatic database migration on startup.
  - Includes Automapper for object mapping.
  - Example `Todo` entity to help you get started.

_For more details, visit the template's [README](./CleanArchitectureTemplate/README.md).

## How to Use

### Visual Studio
1. Download the extension from the [Visual Studio Marketplace](https://marketplace.visualstudio.com).
2. Open Visual Studio and navigate to **File > New > Project**.
3. Search for the desired template and follow the wizard to configure your project.

### Using .NET CLI
You can also use the templates directly from the .NET CLI:

```bash
dotnet new [short-name] -n YourProjectName
```

Replace `[short-name]` with the CLI short name of the template you want to use.

## Contributing
Contributions are welcome! If you have ideas for new templates, improvements to existing ones, or have found any issues, feel free to:
- Open an issue.
- Submit a pull request.

### Adding a New Template
1. Create a folder for your template under the repository root.
2. Include the template files and a `README.md` explaining its usage.
3. Update this main `README.md` to list the new template.

## License
All templates in this repository are licensed under the MIT License. See the [LICENSE](./LICENSE) file for details.

