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

  Screenshots:
  
Home page
<img width="1912" height="851" alt="manual POE 16 " src="https://github.com/user-attachments/assets/8a23dca7-e7b5-427b-9aad-9f81b769c36a" />

Donor registration and login
<img width="1580" height="963" alt="manual POE 1" src="https://github.com/user-attachments/assets/dd40eaea-bf20-4325-91cd-74cfc7f6d7d5" />

Login
<img width="1888" height="822" alt="manual POE 4" src="https://github.com/user-attachments/assets/99896cf8-07c3-449a-a14b-7803c0eec134" />

Making a donation
<img width="1907" height="815" alt="manual POE 6" src="https://github.com/user-attachments/assets/c5ed8b17-ac0a-41bf-a63e-ff4b06f158ad" />

Donation form
<img width="1917" height="767" alt="manual eub" src="https://github.com/user-attachments/assets/3b4e7011-6263-4450-a434-07e7bf430859" />

Volunteer sign-up
<img width="1910" height="852" alt="image" src="https://github.com/user-attachments/assets/c09c97ee-5ab4-4d3d-ad26-3297b5550a5b" />

Volunteer sign-up
<img width="1918" height="892" alt="image" src="https://github.com/user-attachments/assets/6f899b8b-5a91-46ee-872e-38ac532efc3c" />

Employee dashboard
<img width="1902" height="832" alt="manual POE 9,1 " src="https://github.com/user-attachments/assets/0e3842e1-100f-464b-915c-35599b4560ba" />

Employee dashboard
<img width="1912" height="886" alt="manual POE 9,2" src="https://github.com/user-attachments/assets/737bb319-ace2-4e83-a868-0625569b787e" />

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
