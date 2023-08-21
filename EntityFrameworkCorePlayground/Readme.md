# How to create a migration
- Since this is a separate project, make sure the 
	- "EntityFramework.Design" nuget package is installed in startup project
	- Refer this project in startup project
## Migration using VS
 ```
 Add-Migration InitialCreate

 Update-Database
```

## Migration using cli
```cli
dotnet tool install -g dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef databse update
```
