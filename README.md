# Readme

Working from https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-6.0#recommended-learning-path

## Tutorial 1

Get started with Razor Pages (done)
- https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/razor-pages-start?view=aspnetcore-6.0&tabs=visual-studio-code

## Generate City model

      $ dotnet-aspnet-codegenerator razorpage -m City -dc RazorPagesCityContext -udl -outDir Pages/Cities --referenceScriptLibraries -sqlite

      -m	                        The name of the model.
      -dc	                        The DbContext class to use.
      -udl	                    Use the default layout.
      -outDir	                    The relative output folder path to create the views.
      --referenceScriptLibraries	Adds _ValidationScriptsPartial to Edit and Create pages

      Building project ...
      Finding the generator 'razorpage'...
      Running the generator 'razorpage'...

      Minimal hosting scenario!
      Generating a new DbContext class 'RazorPagesCityContext'
      Attempting to compile the application in memory with the added DbContext.
      Attempting to figure out the EntityFramework metadata for the model and DbContext: 'City'
      info: Microsoft.EntityFrameworkCore.Infrastructure[10403]
            Entity Framework Core 6.0.8 initialized 'RazorPagesCityContext' using provider 'Microsoft.EntityFrameworkCore.Sqlite:6.0.8' with options: None
      Added DbContext : '\Data\RazorPagesCityContext.cs'
      Added Razor Page : \Pages/Cities\Create.cshtml
      Added PageModel : \Pages/Cities\Create.cshtml.cs
      Added Razor Page : \Pages/Cities\Edit.cshtml
      Added PageModel : \Pages/Cities\Edit.cshtml.cs
      Added Razor Page : \Pages/Cities\Details.cshtml
      Added PageModel : \Pages/Cities\Details.cshtml.cs
      Added Razor Page : \Pages/Cities\Delete.cshtml
      Added PageModel : \Pages/Cities\Delete.cshtml.cs
      Added Razor Page : \Pages/Cities\Index.cshtml
      Added PageModel : \Pages/Cities\Index.cshtml.cs
      RunTime 00:00:08.70


      $ dotnet ef migrations add Init

      Build started...
      Build succeeded.
      info: Microsoft.EntityFrameworkCore.Infrastructure[10403]
            Entity Framework Core 6.0.8 initialized 'RazorPagesCityContext' using provider 'Microsoft.EntityFrameworkCore.Sqlite:6.0.8' with options: None
      Done. To undo this action, use 'ef migrations remove'


      $ dotnet ef database update

      Build started...
      Build succeeded.
      info: Microsoft.EntityFrameworkCore.Infrastructure[10403]
            Entity Framework Core 6.0.8 initialized 'RazorPagesCityContext' using provider 'Microsoft.EntityFrameworkCore.Sqlite:6.0.8' with options: None
      info: Microsoft.EntityFrameworkCore.Database.Command[20101]
            Executed DbCommand (7ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
            SELECT COUNT(*) FROM "sqlite_master" WHERE "name" = '__EFMigrationsHistory' AND "type" = 'table';
      info: Microsoft.EntityFrameworkCore.Database.Command[20101]
            Executed DbCommand (5ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
            CREATE TABLE "__EFMigrationsHistory" (
            "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
            "ProductVersion" TEXT NOT NULL
            );
      info: Microsoft.EntityFrameworkCore.Database.Command[20101]
            Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
            SELECT COUNT(*) FROM "sqlite_master" WHERE "name" = '__EFMigrationsHistory' AND "type" = 'table';
      info: Microsoft.EntityFrameworkCore.Database.Command[20101]
            Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
            SELECT "MigrationId", "ProductVersion"
            FROM "__EFMigrationsHistory"
            ORDER BY "MigrationId";
      info: Microsoft.EntityFrameworkCore.Migrations[20402]
            Applying migration '20220816083932_Init'.
      Applying migration '20220816083932_Init'.
      info: Microsoft.EntityFrameworkCore.Database.Command[20101]
            Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
            CREATE TABLE "City" (
            "Id" INTEGER NOT NULL CONSTRAINT "PK_City" PRIMARY KEY AUTOINCREMENT,
            "Name" TEXT NOT NULL,
            "PublishDate" TEXT NOT NULL,
            "Json" TEXT NOT NULL
            );
      info: Microsoft.EntityFrameworkCore.Database.Command[20101]
            Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
            INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
            VALUES ('20220816083932_Init', '6.0.8');
      Done.

## Add country property to City model

update code then

      $ dotnet ef migrations add AddCountryToCity

      Build started...
      Build succeeded.
      info: Microsoft.EntityFrameworkCore.Infrastructure[10403]
            Entity Framework Core 6.0.8 initialized 'RazorPagesCityContext' using provider 'Microsoft.EntityFrameworkCore.Sqlite:6.0.8' with options: None
      Done. To undo this action, use 'ef migrations remove'


      $ dotnet ef database update

      Build started...
      Build succeeded.
      info: Microsoft.EntityFrameworkCore.Infrastructure[10403]
            Entity Framework Core 6.0.8 initialized 'RazorPagesCityContext' using provider 'Microsoft.EntityFrameworkCore.Sqlite:6.0.8' with options: None
      info: Microsoft.EntityFrameworkCore.Database.Command[20101]
            Executed DbCommand (7ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
            SELECT COUNT(*) FROM "sqlite_master" WHERE "name" = '__EFMigrationsHistory' AND "type" = 'table';
            SELECT COUNT(*) FROM "sqlite_master" WHERE "name" = '__EFMigrationsHistory' AND "type" = 'table';
      info: Microsoft.EntityFrameworkCore.Database.Command[20101]
            Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
            SELECT "MigrationId", "ProductVersion"
            FROM "__EFMigrationsHistory"
            ORDER BY "MigrationId";
      info: Microsoft.EntityFrameworkCore.Migrations[20402]
            Applying migration '20220817142617_AddCountryToCity'.
      Applying migration '20220817142617_AddCountryToCity'.
      info: Microsoft.EntityFrameworkCore.Database.Command[20101]
            Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
            ALTER TABLE "City" ADD "Country" TEXT NOT NULL DEFAULT '';
      info: Microsoft.EntityFrameworkCore.Database.Command[20101]
            Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
            INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
            VALUES ('20220817142617_AddCountryToCity', '6.0.8');

## Add annotations to City model

I'm using sqlite locally and it seems it *cannot* update these using something like:

      dotnet ef migrations add AddValidationToCity

## Tutorial 2

Get started with MVC (current)
- https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-6.0&tabs=visual-studio-code

## Scaffold city page for MVC part

Share the City model from the Razor part.

dotnet-aspnet-codegenerator controller -name CitiesController -m City -dc MvcCityContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries -sqlite


## Then

https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection
https://docs.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles#dependency-inversion
https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api
