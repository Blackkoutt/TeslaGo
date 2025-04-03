# Table Of Content

- [General info](#general-info)
- [Technologies](#technologies)
- [Documentation](#documentation)
- [Getting Started](#getting-started)

# General info

The aim of the project is to develop a web application that allows users to rent Tesla cars in Mallorca, create reservations for specified date ranges, calculate the total cost, and store reservation details in a database, with the option to pick up and return cars at multiple locations.

# Documentation

The project documentation is available on Confluence. You can access it using the following link: [![Confluence](https://img.shields.io/badge/confluence-%23172BF4.svg?style=for-the-badge&logo=confluence&logoColor=white)](https://mateuszstrapczuk-1743517006225.atlassian.net/wiki/spaces/TeslaRent/folder/622639?atlOrigin=eyJpIjoiMDc2NzFlNzY2NjdiNGE5NTkyMGE3ZTNjNzYzNzkxNmQiLCJwIjoiYyJ9)

# Technologies

Project is created with:

[![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/)
[![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white)](https://learn.microsoft.com/en-us/sql)
[![React](https://img.shields.io/badge/react-%2320232a.svg?style=for-the-badge&logo=react&logoColor=%2361DAFB)](https://react.dev/learn)
[![Vite](https://img.shields.io/badge/vite-%23646CFF.svg?style=for-the-badge&logo=vite&logoColor=white)](https://vite.dev/guide/)
[![TailwindCSS](https://img.shields.io/badge/tailwindcss-%2338B2AC.svg?style=for-the-badge&logo=tailwind-css&logoColor=white)](https://tailwindcss.com/docs)
[![TypeScript](https://img.shields.io/badge/typescript-%23007ACC.svg?style=for-the-badge&logo=typescript&logoColor=white)](https://www.typescriptlang.org/docs/)

# Getting Started

1. Clone the repository
   ```sh
   git clone https://github.com/Blackkoutt/TeslaGo.git
   ```

## Backend project (ASP .NET Core)

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
6. Run the project
   ```sh
   dotnet run --project TeslaGoAPI --launch-profile "https"
   ```
7. Test the API
   Once the project is running, you can test the API by navigating to **Scalar**:
   **https://localhost:7060/scalar/v1**

## Frontend project (React + Vite)

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
