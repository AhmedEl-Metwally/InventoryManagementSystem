# InventoryManagementSystem

A professional, enterprise-grade Inventory Management System built with **.NET 10** following **Clean Architecture** and **CQRS** patterns. This system manages products, sales, and supplies while providing real-time analytics and automated alerts.

## 🚀 Technical Stack
*   **Framework:** .NET 10 Web API
*   **Architecture:** Clean Architecture (Domain, Application, Infrastructure, API)
*   **Patterns:** CQRS with MediatR, Repository Pattern, Unit of Work, Specification Pattern.
*   **Security:** ASP.NET Core Identity, JWT Authentication (Access & Refresh Tokens), Role-Based Access Control (RBAC).
*   **Database:** SQL Server with Entity Framework Core.
*   **Validation & Mapping:** FluentValidation, Mapster.
*   **Tools:** MailKit (SMTP Email Alerts), Memory Caching, MediatR Pipeline Behaviors.

## ✨ Key Features
*   **Advanced Dashboard:** Real-time calculation of total inventory value, sales revenue, and top-selling products.
*   **Role-Based Access:** Dedicated permissions for **Admin**, **Manager**, and **Staff** roles.
*   **Automated Alerts:** Instant email notifications when stock levels fall below safety thresholds.
*   **Secure Auth:** Fully implemented JWT lifecycle including secure login and token refresh logic.
*   **Global Error Handling:** Standardized API responses using custom Middleware.
*   **Performance Optimized:** Integrated caching and pipeline behaviors for request validation and logging.

## 🏗️ Architecture Overview
The project is divided into four main layers:
1.  **Domain:** Core entities, exceptions, and business logic.
2.  **Application:** MediatR Commands/Queries, DTOs, Mapping, and Interfaces.
3.  **Infrastructure:** Data persistence (EF Core), Identity configuration, and external services (Email, JWT).
4.  **API:** Controllers, Middlewares, and Dependency Injection registration.

## ⚙️ Configuration
To run this project, you will need to add the following to your `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnectionString": "Your_App_DB_Connection",
    "IdentityConnectionString": "Your_Identity_DB_Connection"
  },
  "JwtSettings": {
    "SecretKey": "Your_Secret_Key",
    "ExpiryMinutes": 60
  },
  "EmailSettings": {
    "SmtpServer": "smtp.gmail.com",
    "SmtpUsername": "your_email@gmail.com",
    "SmtpPassword": "your_app_password"
  }
}
