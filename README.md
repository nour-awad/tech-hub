# Tech-Hub

Tech Hub is a web application designed to streamline the operations of an online tech store. It provides users with a user-friendly interface to browse, select, and purchase tech products, while also offering efficient tools for administrators to manage the store's inventory and orders.

## Table of Contents

- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [License](#license)

## Getting Started

### Prerequisites

Before you begin, ensure you have the following prerequisites installed:

- [ASP.NET Core](https://dotnet.microsoft.com/download)
- [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server/)

### Installation

1. Clone the repository: `git clone https://github.com/nour-awad/tech-hub.git`
2. Navigate to the project directory: `cd online-tech-hub`
3. Restore NuGet packages: `dotnet restore`
4. Set up the Microsoft SQL Server database:
   - Create a new database in SQL Server Management Studio (SSMS).
   - Execute the SQL script provided in [To Be Added] to create the necessary tables.
5. Configure the database connection in the `appsettings.json` file.
   - Update the `ConnectionStrings` section with your MSSQL server details.
6. Run the application: `dotnet run`

## License

This project is licensed under the [MIT License](LICENSE).
