# Gift of the Givers Web Application

A prototype web application for Gift of the Givers, built with ASP.NET Core MVC. It lets donors give and volunteers sign up, while employees manage everything from a dashboard.

A personal project built to practise full-stack development with ASP.NET Core and Azure.

## Features

- Register and log in with two roles: **Donor** and **Employee**
- Donors can make donations
- Volunteers can sign up to help
- Employee dashboard to view and manage donations and volunteers
- Gift of the Givers branding throughout the site
- Azure Functions project for background tasks
- Custom NuGet helper library published on Azure Artifacts
- CI build with Azure Pipelines
- Unit, integration, load/stress and Selenium UI tests

## Tech Stack

| Area | Technology |
|------|------------|
| Web app | ASP.NET Core MVC (C#) |
| Authentication | ASP.NET Core Identity with roles |
| Database | Azure SQL |
| Background tasks | Azure Functions |
| Shared code | Custom NuGet package (Azure Artifacts) |
| Source control | Azure Repos (Git) |
| CI/CD | Azure Pipelines |
| Hosting | Azure App Service |
| Project tracking | Azure DevOps Boards |

## Getting Started

### Prerequisites

- .NET SDK (version used by the project)
- Visual Studio 2022 or later
- Access to the Azure SQL database
- Git

### Run it locally

1. Clone the repository:
   ```
   https://ST10435250@dev.azure.com/ST10435250/Gift%20of%20the%20Givers%20Disaster%20Relief%20System/_git/GiftOfTheGivers
   ```
2. Open the solution file (`.sln`) in Visual Studio.
3. In `appsettings.json`, set the database connection string:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "<your-azure-sql-connection-string>"
   }
   ```
4. Apply the database migrations in the Package Manager Console:
   ```
   Update-Database
   ```
5. Press **F5** to run the app.

### Default roles

The app uses two roles: `Employee` and `Donor`. New users register as donors, and employee accounts are set up by the team.

## Project Structure

```
├── GiftOfTheGivers/             # ASP.NET Core MVC web app
├── GiftOfTheGivers.Functions/   # Azure Functions project
├── GiftOfTheGivers.Helpers/     # Custom NuGet helper library
├── GiftOfTheGivers.Tests/       # Unit, integration and UI tests
├── GiftOfTheGivers.slnx         # Solution file
├── azure-pipelines.yml          # Azure Pipelines CI build
├── migration.sql                # Database migration script
├── dbo.AspNetRoles.data.sql     # Seed data for the Employee and Donor roles
├── load-test.js                 # Load test script
├── stress-test.js               # Stress test script
├── nuget.config                 # NuGet feed configuration
├── .gitattributes
└── .gitignore
```

Folder names may differ slightly in the actual solution.

## Testing

Run the unit and integration tests from Visual Studio's Test Explorer, or with:

```
dotnet test
```

Load and stress tests and the Selenium UI tests are run separately. The tests are also wired into the Azure Pipeline so they run on every build.

## Deployment

The app is deployed to Azure:

- Web app: Azure App Service
- Functions: Azure Functions
- Database: Azure SQL

Deployment is handled through Azure Pipelines.

## Author

Zwivhuya Prudence Maphalaphatwa (Zee)
