# 🌡️ Health Check

This project demonstrates an ASP.NET Core application with integrated health checks for Redis and MongoDB, along with a simple weather forecast API.

## ✨ Features

- **Health Checks**: Monitors the status of Redis and MongoDB databases. 📊
- **Health Checks UI**: Provides a web-based dashboard for viewing health check results. 💻

## 🛠️ Technologies Used

- ASP.NET Core
- HealthChecks.UI
- Redis
- MongoDB
- PostgreSQL (for storing health check results)

## 🚀 Getting Started

### 📋 Prerequisites

- .NET 8 SDK or later
- Redis server
- MongoDB server
- PostgreSQL server

### 🔧 Installation

1. **Clone the repository:**

    ```bash
    git clone https://github.com/your-username/your-repo.git
    cd your-repo
    ```

2. **Restore dependencies:**

    ```bash
    dotnet restore
    ```

3. **Update the connection strings** in `Program.cs` with your Redis, MongoDB, and PostgreSQL connection details. Specifically, update the PostgreSQL connection string in the following line:

    ```csharp
    .AddPostgreSqlStorage(connectionString: "User ID=postgres;Password=yourpassword;Host=yourhost;Port=yourport;Database=yourdatabase;");
    ```

4. **Run the application:**

    ```bash
    dotnet run
    ```

### 📚 Usage

- **Health Checks:**
  - Access the health check endpoint at: `https://localhost:5001/health` ✅
  - View the Health Checks UI at: `https://localhost:5001/hc` 📈

- **Weather Forecast API:**
  - Access the weather forecast endpoint at: `https://localhost:5001/weatherforecast` 🌤️
