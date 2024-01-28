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
   -  Open your terminal/command line & scaffold the connection string to the models (the `-f` at the end is to overwrite what's already there)
   -  `dotnet ef dbcontext scaffold "Server=localhost,1433;Database=<YOUR DATABASE NAME>;TrustServerCertificate=True;User=<YOUR USER NAME>;PASSWORD=<YOUR PASSWORD>" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models -f`
   -  NOTES:
      -  if `dotnet ef` package doesn't exist, run `dotnet tool install --global dotnet-ef`, then try again. Make sure the connection string, inside the quotes, is correct.
      -  You may have to manually create a database, before running the `scaffold` command, to connect to. I used Docker to install and rung Sql Server, I used Tableplus to connect to Sql Server, & then manually created a Database "SuperHero". Afterwards, I was able to run the `scaffold` command.
-  In terminal/command line, run:
   -  `dotnet restore` to download all packages
   -  See list of packages in `SuperheroApi.csproj` file
-  Run in terminal/command line `dotnet run` to get local instance running
-  In another terminal/command line, cd into the `client` folder
-  Once in the client folder, run:
   -  `npm install` to download the required packages
   -  `npm run dev` to get local instance of the client running
   -  Make sure in the `client/utilities/dbUtils.ts` file, the variable on top of the page `host` matches the correct port your C# app is running on.
-  Open webpage, go to `http://localhost:3000` (or whatever port your client is running on), create your first super hero!

### Demo Video

-  Demo of the application (https://www.loom.com/share/187ca3b4579047bc94f3b4202fafb33d?sid=c2633b49-9bee-48a0-9f5e-71eae67d12d6)
