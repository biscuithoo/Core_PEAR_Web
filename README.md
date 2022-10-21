# PEAR Core Web

Migrating from **ASP.NET MVC5 and EntityFramework6** to **ASP.NET Core and EntityFramework Core**

---

## Download
1. [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/)
2. [ASP.NET 5.0 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
    - .NET Core 5.0 SDK is named as `Microsoft .NET 5.0.xx` , not to be confused with `Microsoft [ASP.NET](http://asp.NET) MVC 4/5`
3. Microsoft SQL Server Management Studio

---
## Database

There will be **2** databases from now on. One in your local machine and one hosted on the server. Please do your testing and development on the **local db only**. You can populate any necessary data required for your testing below. 

- This is to ensure that the database in the server is kept clean and will not lead to any data descrepancy from testing during development. 
- Using local db allows you to delete and recreate the entire database with the necessary data populated without affecting others.

### Creating DB locally

1. Expand `appsettings.json` and select `appsettings.Development.json`
2. Specify/Change your local db connection string under `ConnectionStrings` and change `Startup.cs` accordingly (configure database connection comment)
3. Open _Nuget Package Manager Console_ (Tools/Nuget Package Manager/) and execute `Update-Database` - this will create a new database if it doesn't not already exist and and tables if specified in `Migrations/`

### Migrations (Changes to models/data)

#### **In Local DB**
 **For now only**
1. Delete files under Migration folder
2. Run `Add-Migration InitialCreate` in _Nuget Package Manager Console_
3. Delete database in localdb
4. Run `Update-Database`

**Future**
1. Made changes to model file directly
2. Run `Add-Migration <changes made>`  in _Nuget Package Manager Console_
3. Run `Update-Database`

### Seeding Data

**For now only**
- Similar to Changes to model

**Future**
1. Add in  `Data/ModelBuilderExtensions.cs` file.
2. Run `Add-Migration <changes made>`
3. Run `update-database`

[Reference](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=vs)

#### In Server
To update migration to server, (currently can't figure out away to use configuration in `appsettings.json`...) 

1. In `appsettings.Development.json` change LocalDb to ServerDb connection string
2. Run `update-database` to apply Migration to Db in Server 
3. Revert back changes made in `appsettings.Development.json` to point back to your local Db

---

## Web Deployment and Publishing

Should always be done when changes are made to the code. This is to update the website hosted.

1. Click **Build** -> **Publish**
2. Custom profile should be saved in project already. Alternatively, key in the following web deployment credentials: <br />
   Server: coreMvc.fyp2017.com <br />
   Username: fypcom <br />
   Password: 6Tnl78v^ <br />
3. Validate connection <br />
4. Finish
5. Click Edit > Settings
6. Ensure under Databases Tab, use this connection string at runtime is checked and pointing to the correct database (pearCore)
7. Save and Publish

### web.config

IIS Server blocking PUT and DELETE HTTP requests. Added web.config file [1](https://github.com/aspnet/IISIntegration/blob/4334fe19f29827d2a12830e0332164e991328076/samples/IISSample/web.config) to remove webdav module [2](https://github.com/aspnet/IISIntegration/issues/346) and change handlers to AspNetCoreModuleV2 [3](https://stackoverflow.com/questions/53943601/the-transformwebconfig-task-failed-unexpectedly-system-exception-the-accept)   

---

## Code Practices (Draft)

Please follow and be responsible, don't want the code base to end up like PEAR 17...

### Do
- Add **Comments** to code and methods implemented whenever necessary to explain how/what the code does
   - Able to understand what the method/code does without the need to read in detail
   - Ensures no misunderstanding when others edit/reuse the code/methods implemented
- Write code in the correct places - Controllers vs ApiControllers, Services, Repository (Refer to ???. Backend Migration Plan for now)
- ~~Use ViewModels and DTOs whenever necessary and correctly~~

### Don'ts
- Push BROKEN code / Code that failed the Build process
- Push code with multiple blocks of empty lines, line break only when necessary

Example:
``` 
/ some code here
// empty space
// empty space
// empty space
//some code here again
```

### Code implementation

When migrating features in PEAR 17 to PEAR Core, do not blindly copy and paste the codes over.

1. Understand what the feature does and which user is it for (from code implemented/documentation)
2. Clarify with Prof if understanding is correct and **document it** down
3. Due to changes made during migration, the old implementation might be different from how it should be implemented here. 
   - Refer to [schema changes document](https://docs.google.com/spreadsheets/d/1VWvd3oCGXYv7KyTkNP7MhcjpY3rZh22uvTnbq12LYbE/edit#gid=256273126) to see the reason it was remove etc.
4. ONLY if necessary, make changes to the model and **document it** down



