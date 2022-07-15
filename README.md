# LibreriaAPI

## Installing dotnet-ef

```
dotnet tool install --global dotnet-ef
```

* To update the **dotnet-ef** tool use `dotnet tool update --global dotnet-ef`
* To verify that you installed the **dotnet-ef** tool correctly use `dotnet-ef -v`

```

                     _/\__
               ---==/    \\
         ___  ___   |.    \|\
        | __|| __|  |  )   \\\
        | _| | _|   \_/ |  //|\\
        |___||_|       /   \\\/\\

Entity Framework Core .NET Command-line Tools 6.0.5

```


## Installing necessary nugets

```
dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.17
```

```
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 5.0.17
```

```
dotnet add package Microsoft.EntityFrameworkCore --version 5.0.17
```

## Scaffolding 

```
dotnet ef dbcontext scaffold "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Chinook;user=aaa;password=123" Microsoft.EntityFrameworkCore.SqlServer --output-dir Entities/ --context-dir Entities/
```

If you want to know more about Reverse Engineering visit [Reverse Egineering (Scaffolding)](https://docs.microsoft.com/en-us/ef/core/managing-schemas/scaffolding?tabs=dotnet-core-cli)

## Migration

```
dotnet ef migrations add InitialCreate
```

```
dotnet ef database update
```

If you want to know more about Migrations, take a look at [Migrations Overview](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)

## Additional nugets

* **BCrypt** is a library uses to encrypt passwords securely

```
dotnet add package BCrypt.Net-Next
```

* **JWT (Json Web Token)** is used to implement authentication and authorization to your APIs, to learn more about JWT visit [jwt.io](jwt.io)

```
dotnet add package System.IdentityModel.Tokens.Jwt
```

```
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 5.0.17
```