# Excursion booking platform API

This API provides a number of endpoints designed to manage various excursion-related tasks, including processing reservations, managing excursion information.

## Key Features

### User Authentication

- **User Registration**: Allows new users to create accounts by providing necessary information.
- **User Login**: Enables registered users to log in securely to access booking features.

### Administrator interface

- **Find, add, update, and delete objects**: Gives administrators full control over system objects, enabling efficient management of tours and other components.

## Architecture

### Clean Architecture

- **Web**: Controllers for handling requests and managing client-server communication.
- **Application Layer**: Implements business logic and orchestrates interactions between components.
- **Domain Layer**: Contains fundamental business rules and entities.
- **Data Access Layer**: Manages external resources such as databases.

## Technology Stack Overview

### Technologies Used

- **C#**: Main programming language.
- **ASP.NET Core**: Framework for building high-performance, cross-platform web APIs.

### Database

- **Entity Framework Core**: Employing Entity Framework Core for streamlined object-relational mapping (ORM) within the .NET ecosystem, simplifying database interactions.
- **MS SQL Server**: Utilizing MS SQL Server for reliable and scalable backend database management, ensuring efficient storage and retrieval of application data.

### API Design

- **Swagger UI**: Provides a user-friendly interface for API interaction.

### Authentication and Authorization

- **JWT (JSON Web Tokens)**: For secure transmission of information between parties.

### Monitoring and Logging

- **Serilog**: Logging library for .NET applications.

### Design Patterns

- **RESTful Principles**: Adhering to RESTful design principles to ensure that APIs are designed for simplicity, scalability, and ease of use.
- **Repository Pattern**: Implementing the repository pattern to abstract the data layer, enhancing application maintainability, testability, and cleanliness by decoupling data access logic from business logic.
- **Options Pattern**: For efficient configuration management within the application.
- **Unit of Work**: Manages transactions across multiple data operations, ensuring atomicity and data consistency within a single logical unit.
