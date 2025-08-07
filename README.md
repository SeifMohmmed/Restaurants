# 🍽️ Restaurants API

A robust and scalable Web API built using **.NET 9.0**, implementing **Clean Architecture** principles to manage restaurants, dishes, orders, and users.

---

## 🏗️ Project Structure

- `src/Restaurants.API` – Entry point of the application.
- `src/Restaurants.Application` – Business logic and CQRS handlers.
- `src/Restaurants.Domain` – Core enterprise logic and entities.
- `src/Restaurants.Infrastructure` – Data access, logging, and external services.
- `tests/*` – Unit and integration tests using xUnit.

---

## 🎯 Features

### 🏪 Restaurant Management

- **Create Restaurants**: Authenticated users can register new restaurants they own.
- **Update Restaurant Info**: Modify restaurant details like name, description, delivery availability, etc.
- **Delete Restaurants**: Owners can delete their restaurants, with built-in authorization checks.
- **Get All Restaurants**: Supports pagination, filtering, and sorting for efficient browsing.
- **View Restaurant Details**: Retrieve information for a specific restaurant by its ID.

### 🍽️ Dish Management

- **Get Dishes by Restaurant**: Fetch all dishes belonging to a particular restaurant.
- **Get Specific Dish**: Retrieve details of a specific dish within a restaurant.

### 📚 Category Management

- **Create Category**: Add new food categories (e.g., Pizza, Dessert), with duplicate name validation.
- **Update Category**: Modify existing category information.
- **Delete Category**: Permanently remove a category.
- **List Categories**: Retrieve all categories with support for pagination, search, and sorting.
- **Get Category by ID/Name**: View detailed category info via ID or name.

### 🧑‍🍳 Customer Management

- **List Customers**: Admins can retrieve all customers with search and pagination support.
- **Get Customer Details**: View detailed profile information for a specific customer.

### 📦 Order Management

- **List Orders**: View all placed orders with pagination and sorting.
- **Get Order by ID**: Retrieve a specific order along with its items.

### ⭐ Rating System

- **List Ratings**: Access all ratings across the system, including filtering and sorting.
- **Get Rating Details**: Retrieve a rating along with linked dish, restaurant, and customer info.

### 👤 User Profile & Role Management

- **Assign User Role**: Admins can assign users to roles (e.g., Admin, RestaurantOwner).
- **Unassign User Role**: Remove a role from a user account.
- **Update Profile Info**: Authenticated users can update their nationality and date of birth.

### 🔐 Authorization & Logging

- **Fine-grained Authorization**: Actions like updating or deleting a restaurant require ownership or admin rights.
- **Serilog Logging**: Every significant action is logged for observability and auditing.
- **Exception Handling**: Built-in error responses for not found, forbidden, or duplicate resource actions.


## 📸 Screenshots
### 🗂️ Class Diagram
<p align="center">
  <img src="https://github.com/SeifMohmmed/Restaurants/blob/cb9128b9264dd2d8df4105dbcb13aa2c6e3144db/Screenshots/Class%20Diagram.png" alt="image alt"/>
</p>

<br>

### 🌐 Endpoints

 <p align="center">
  <img src="https://github.com/SeifMohmmed/Restaurants/blob/cb9128b9264dd2d8df4105dbcb13aa2c6e3144db/Screenshots/Enpoints.png" alt="image alt"/>
</p>


## 📦 Packages & Libraries

- **Serilog** – Structured and customizable logging.
- **MediatR** – Implements CQRS pattern with clean separation of commands and queries.
- **Entity Framework Core** – ORM for data access.
- **Azure Storage** – Blob storage for handling media and files.
- **Microsoft Identity** – Authentication, authorization, and role-based access control.
- **xUnit** – Unit testing framework used to validate application behavior.

## 🧪 Testing

This project uses **xUnit** for testing and includes unit and integration test coverage for most major features.

### Running Tests

You can run the tests using the **Test Explorer** in Visual Studio or via CLI:

```bash
dotnet test tests/Restaurants.[Layer].Tests
```

Tests cover:
- Handlers (Commands & Queries)
- Validation rules
- Controller actions
- Authorization logic
- Integration scenarios

---

## 🚀 Getting Started

### ✅ Prerequisites

- .NET 9.0 SDK
- Visual Studio 2022 or later

### ⚙️ Build the Solution

```bash
Open Restaurants.sln in Visual Studio and build the solution.
```

### ▶️ Run the API

```bash
Set `Restaurants.API` as the startup project and run the application.
```
