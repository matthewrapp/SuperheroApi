# Documentation

### Tools used

-  VS Code (Visual Studio no longer supports Mac OS)
-  dotnet & npm packages
-  Docker (Container for Sql Server)
   -  Only way to run a Sql Server instance on Mac OS, as far as I was able to research
-  Tableplus (Database Visual)
-  Github
-  C# Extension

### Programming Languages

-  C# / .NET for the server
-  React / Nextjs for the client

### Get Started

-  Make sure you are in correct path (Root of the project)
-  Configuration:
   -  Go to `client/utilities/dbUtils.ts` file & set your `host` variable to match your C# app.
   -  Go to `appsettings.json` file & set your database connection string
      -  Make sure the 'User' & 'PASSWORD' values are changed to your local connection details.
-  I used the dotnet ef package to run migrations to connect my database to my models
   -  Open your terminal/command line & scaffold the connection string to the models
   -  `dotnet ef dbcontext scaffold "Server=localhost,1433;Database=SuperHero;TrustServerCertificate=True;User=sa;PASSWORD=<YourStrong@Passw0rd>" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models`
   -  NOTE: if `dotnet ef` package doesn't exist, run `dotnet tool install --global dotnet-ef`, then try again. Make sure the connection string, inside the quotes, is correct.
-  Run in terminal/command line `dotnet restore` to download all packages
   -  See list of packages in `SuperheroApi.csproj` file
-  Run in terminal/command line `dotnet run` to get local instance running
-  In another terminal/command line, cd into the `client` folder
-  Once in the client folder, run `npm run dev` to get local instance of the client running
   -  Make sure in the `client/utilities/dbUtils.ts` file, the variable on top of the page `host` matches the correct port your C# app is running on.
-  Open webpage, go to `http://localhost:3000` (or whatever port your client is running on), create your first super hero!

-  `dotnet new webapi --use-controllers -o SuperheroApi`
-  `dotnet run`

# Install Entity Framework

-  `dotnet tool install --global dotnet-ef`
-  `dotnet add package Microsoft.EntityFrameworkCore.Design`
-  `dotnet add package Microsoft.EntityFrameworkCore.SqlServer`

# Connect to db

-  Scaffold
   -  `dotnet ef dbcontext scaffold "Server=localhost,1433;Database=SuperHero;TrustServerCertificate=True;User=sa;PASSWORD=<YourStrong@Passw0rd>" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models`
      <!-- -  `dotnet ef dbcontext scaffold "Server=localhost,1433;Database=SuperHero;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models` -->
      <!-- -  `dotnet ef dbcontext scaffold "Server=localhost,1433;Database=SuperHero;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models` -->
