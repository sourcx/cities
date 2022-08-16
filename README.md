# Readme 

## Tutorial

https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-6.0#recommended-learning-path
  https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/razor-pages-start?view=aspnetcore-6.0&tabs=visual-studio-code

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
