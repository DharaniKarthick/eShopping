# eShopping

MoneStore is an ASP.NET Core application that includes a full-featured e-commerce system.

## Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- SQL Server
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) (optional, but recommended)

## Getting Started

Update the database connection in appsettings.json

Run the command to install Entity Framework tools
dotnet tool install --global dotnet-ef

Run the Command to update the database
dotnet ef database update

## Project Structure
Controllers/ - Contains the MVC controllers.
Models/ - Contains the entity models.
Views/ - Contains the Razor views.
Data/ - Contains the ApplicationDbContext and migrations.
Areas/ - Contains the Identity details of the user.
Services/ - Contains the repository interfaces and implementations.

## Repository Pattern
MoneStore uses the Repository Pattern to manage data access. This pattern provides a collection-like interface for accessing domain objects and abstracts the data access logic from the business logic.







