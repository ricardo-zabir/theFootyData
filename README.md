# The Footy Data
Welcome to the Footy Data project, This solution is composed of three main components:
- Worker Service: Scheduled via Hangfire, it performs hourly data upserts by retrieving and updating match data.
- Web API: Serves as the backend for the frontend application, exposing endpoints to access the processed data.
- A Vue.js-based application that displays the match data in a dynamic, filterable grid.

## How to run

To run this project locally, a SQL Server instance is required. On a Mac with M1 architecture, the following Docker command can be used to spin up a compatible SQL Server container:

```
docker run -e "ACCEPT_EULA=1" -e "MSSQL_SA_PASSWORD=MyPass@word" -e 
"MSSQL_PID=Developer" -e "MSSQL_USER=SA" -p 1433:1433 -d --name=sql mcr.microsoft.com/azure-sql-edge
```

Once the container is running, connect to it using Azure Data Studio (or any SQL client). After connecting, create the database required for the project with the following SQL:

```
USE master
GO
IF NOT EXISTS (SELECT [name]
FROM sys.databases
WHERE [name] = N'TestDb')
CREATE DATABASE FootyData
GO
```

If your database configuration differs from the default (name, user, or password), ensure that the appsettings.json files for both the Worker Service and Web API are updated accordingly so that Entity Framework Core can connect successfully.

Navigate to the Worker Service project directory and run the following commands to apply the initial migration and create the necessary schema:
```
dotnet ef migrations add InitialCreate
dotnet ef database update
```

With the database and schema set up, you can now run the .NET projects (Worker Service and Web API). Ensure all required NuGet packages are installed before running.

For the Vue project you can install the dependencies using
```
npm install
```

and run the project using command
```
npm run dev
```

## How the Data Upsert function works

The data upsert functionality is triggered hourly by Hangfire. It fetches matches from the [FootballData](https://www.football-data.org/) API, covering a range from 7 days in the past to 7 days in the future, including live matches. This data pertains to England's second-tier football league, the [EFL Championship](https://en.wikipedia.org/wiki/EFL_Championship).
The free tier of the API may introduce minor delays in data updates, but these are generally negligible. Updated scores are reflected on the frontend as new data is ingested.


## Architecture

 - Both backend services follow a consistent architectural approach:

- Entity Framework Core is used for data access.

- The Repository Pattern encapsulates database interactions.

- Domain Models are defined in a shared Models layer.

- In the Web API, Controllers communicate with Services, which in turn access the Repositories.

- The frontend is organized into modular Vue.js components, adhering to standard best practices for maintainable and scalable frontend development.

### Any question on the project can be sent to the e-mail ricardofonseca.zabir@hotmail.com


