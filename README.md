# Task Manager

A full-stack Task Manager application built using **ASP.NET Core Web API**, **Clean Architecture**, **Entity Framework Core**, **SQL Server**, and **Angular**.

---

## Features

### Projects
- Create Project
- View All Projects
- Update Project
- Delete Project

### Tasks
- Create Task
- View All Tasks
- Update Task
- Delete Task
- Assign Task to a Project
- Display Project Name
- Task Status (Pending, In Progress, Completed)

---

## Technologies Used

### Backend
- ASP.NET Core Web API (.NET 10)
- Clean Architecture
- Entity Framework Core
- SQL Server
- AutoMapper

### Frontend
- Angular 20+ (Standalone Components)
- TypeScript
- Bootstrap
- Reactive Forms
- HttpClient

---

## Project Structure

```
TaskManagerProject
│
├── TaskManager        # ASP.NET Core Web API
└── TaskManagerFront   # Angular Application
```

---

## How to Run the Project

### Backend

1. Open the `TaskManager` solution in Visual Studio.
2. Update the SQL Server connection string inside:

```
appsettings.json
```

3. Apply migrations:

```bash
Update-Database
```

or

```bash
dotnet ef database update
```

4. Run the API.

Swagger will be available at:

```
https://localhost:7085/swagger
```

---

### Frontend

Navigate to the Angular project:

```bash
cd TaskManagerFront
```

Install dependencies:

```bash
npm install
```

Run the application:

```bash
ng serve
```

Open:

```
http://localhost:4200
```

---

## Database

- SQL Server
- Entity Framework Core
- Code First Migrations

---

## Design Decisions

- Clean Architecture
- Repository Pattern
- Service Layer
- Dependency Injection
- AutoMapper
- Angular Standalone Components
- RESTful API Design

---

## Future Improvements

- Authentication & Authorization (JWT)
- Search & Filtering
- Pagination
- Unit Testing
- Docker Support
- Role Management

---

## Demo

Demo Video: 

https://drive.google.com/file/d/1w-uVr-G8nHju4X_JacuzEYLcAtb4IIxX/view?usp=sharing

---

## Author

**Mohamed Zakaria**
