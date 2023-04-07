# Criar Projeto

dotnet new webapi

# Packeages

dotnet add package Microsoft.EntityFrameworkCore ***
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package MySql.Data
dotnet add package Pomelo.EntityFrameworkCore.MySql

# Migrations

dotnet ef migrations add CreateDatabase
dotnet ef database update

# rodar

dotnet build
dotnet run
