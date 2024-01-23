# Pet Project: ASP.NET Core MVC User Management System

## Overview
This pet project is developed using ASP.NET Core MVC and Entity Framework to create a simple user management system. The application allows users to perform CRUD (Create, Read, Update, Delete) operations on user entities, including creating users, viewing a list of users, updating user information, and deleting users.

## Features
- **User Creation:** Admin users can create new user accounts by providing necessary details.
- **User Listing:** View a list of all users in the system.
- **User Details:** Retrieve detailed information about a specific user.
- **User Update:** Modify and update user information, such as username, email, and password.
- **User Deletion:** Admin users can delete user accounts.

## Technologies Used
- **ASP.NET Core MVC:** The project is built using the ASP.NET Core MVC framework for creating web applications.
- **C#:** The primary programming language used for server-side development.
- **Entity Framework Core:** For data access and database interactions.
- **HTML, CSS, and JavaScript:** Used for front-end development and enhancing user interactions.
- **Bootstrap:** Utilized for responsive and visually appealing UI.

## Prerequisites
Make sure you have the following installed on your machine:
- [.NET SDK](https://dotnet.microsoft.com/download)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/) (optional)

## Getting Started
1. **Clone the repository:**
   ```bash
   git clone https://github.com/your-username/aspnet-core-mvc-user-management.git
   ```
2. **Navigate to the project directory:**
   ```bash
   cd crud/user_management
   ```
3. **Run the application:**
   ```bash
   dotnet run
   ```
4. Open your web browser and go to [local](http://localhost:5000/) to access the application.

## Configuration
- Database settings can be configured in the 'UserContext.cs' file.
- Modify the connection string to use your preferred database.

## Contributions
Contributions are welcome! If you find any issues or have suggestions for improvement, feel free to create a pull request.
