# <img width="500" height="230" alt="logo_horizontal" src="https://github.com/user-attachments/assets/2e94896f-ff8f-4efd-82f9-d28f7161437d" />

# 📑 Table Of Content

- [ℹ️ General info](#general-info)
- [📋 Assumptions](#assumptions)
- [🧰 Technologies](#technologies)
- [🚀 Getting Started](#getting-started)
  - [⚙️ Backend project (ASP .NET Core)](#backend-project)
  - [🖥️ Frontend project (React + Vite + Tailwind CSS)](#frontend-project)

<h1 id="general-info">ℹ️ General info</h1>

The aim of the project is to develop a web application that allows users to rent Tesla cars in Mallorca, create reservations for specified date ranges, calculate the total cost, and store reservation details in a database, with the option to pick up and return cars at multiple locations.

<h1 id="assumptions">📋 Assumptions</h1>

- **Database and API**:  
  The database and API are designed to be flexible, allowing the system to easily adapt to future changes,  
  such as expanding to new locations or supporting new car brands.
  
- **User Authentication**:  
  Renting a car is available only after successfully signing in to the application.  
  You can either create your own account or use the test credentials below:  
  **Test login**: jan.kowalski@gmail.com  
  **Test password**: 789qaz

- **Administrator Features**:  
  Admin-only functionalities are available via API endpoints and require admin login credentials:  
  **Admin login**: admin@gmail.com  
  **Admin password**: admin123

- **Authentication and Authorization**:  
  The API generates a JWT token upon user login.  
  This token is stored in browser cookies and is included with each request to the backend.

- **Reservation Logic**:  
  If a reservation starts in less than 2 days, a specific car is assigned immediately to that reservation.  
  If a reservation starts in more than 2 days, only the car model is assigned. This avoids blocking a specific car for an extended period.

  The scheduler runs every day at 2AM and checks for reservations starting in the next 2 days that do not have a specific car assigned.  
  If such a reservation is found, it attempts to assign a concrete car with the model and location specified in the reservation.  
  If no matching car is found at the given location, it logs and saves the issue in the database in CarAvailabilityIssue table.  
  The admin can then get information about the issue and decide what to do:  
  - Physically relocate cars  
  - Propose an alternative model or start location to the user  
  - Cancel the reservation if necessary.

- **Rental Management**:  
  After renting a car, users can visit their profile to view their active, expired, and canceled rentals.

- **Canceling Rentals**:  
  Users can only cancel their own rentals.  
  Administrators have the ability to cancel any rental.

- **Car Filtering**:  
  On the Our Fleet page, you can filter available cars by:  
  - Model  
  - Version  
  - Body type  
  - Drive type

- **Car Images**:  
  Images of car models are stored in the TeslaGoAPI.DB/Images/CarModels folder.  
  The database stores only the image file name (not the full path).

<h1 id="technologies">🧰 Technologies</h1>

Project is created with:

[![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/)
[![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white)](https://learn.microsoft.com/en-us/sql)
[![React](https://img.shields.io/badge/react-%2320232a.svg?style=for-the-badge&logo=react&logoColor=%2361DAFB)](https://react.dev/learn)
[![Vite](https://img.shields.io/badge/vite-%23646CFF.svg?style=for-the-badge&logo=vite&logoColor=white)](https://vite.dev/guide/)
[![TailwindCSS](https://img.shields.io/badge/tailwindcss-%2338B2AC.svg?style=for-the-badge&logo=tailwind-css&logoColor=white)](https://tailwindcss.com/docs)
[![TypeScript](https://img.shields.io/badge/typescript-%23007ACC.svg?style=for-the-badge&logo=typescript&logoColor=white)](https://www.typescriptlang.org/docs/)

<h1 id="getting-started">🚀 Getting Started</h1>

1. Clone the repository
   ```sh
   git clone https://github.com/Blackkoutt/TeslaGo.git
   ```

<h3 id="backend-project">⚙️ Backend project (ASP .NET Core)</h3>

To run this project type following command's in terminal:

2. Navigate to the project directory
   ```sh
   cd TeslaGo/TeslaGoAPI
   ```
3. Install .NET SDK 9.0
   This project is built with **.NET 9.0**. Make sure you have **.NET 9.0 SDK** installed on your machine. To check your current version of .NET, run:

   ```sh
   dotnet --version
   ```

   If you don’t have **.NET 9.0**, download and install it from [Microsoft .NET Download](https://dotnet.microsoft.com/download/dotnet/9.0).

4. Restore dependencies
   ```sh
   dotnet restore
   ```
5. Check configuration in `appsettings.json`
   Ensure that your `appsettings.json` contains the correct configuration for your database connection string. Then apply migrations by typing following command:
   ```sh
   dotnet ef database update
   ```
6. Run the project or test the API

   **Run**
   ```sh
   dotnet run --launch-profile "api"
   ```

   **Test**

   If you run the project from Visual Studio, you can test the API using **Swagger**. The browser will automatically open at:  
   **https://localhost:7060/swagger**

<h3 id="frontend-project">🖥️ Frontend project (React + Vite + Tailwind CSS)</h3>

To run this project type following command's in terminal:

2. Navigate to the project directory
   ```sh
   cd TeslaGo/TeslaGoClient
   ```
3. Install dependencies
   ```sh
   npm install
   ```
4. Run the development server
   ```sh
   npm run dev
   ```
5. Test the frontend
   After the development server starts, the frontend application will be available at: **http://localhost:5173**

# 
<p align="right">
  <h5 align="right">© 2025 Blackkoutt •</b> <img width="100" height="230" alt="logo_horizontal" src="https://github.com/user-attachments/assets/2e94896f-ff8f-4efd-82f9-d28f7161437d" />
</p>


