
/* ***** READ ME

    // Update Database
    // Set project start to Ats.Web (as default)
    // Set default project (in PMC) to Ats.Build
    update-database -context BuildDbContext


    // Seeding Data
    bin/Debug/netcore/dotnet Ats.Build.dll

    Reset DB
    Update-Database -Migration 0 -context BuildDbContext


    // Add migration
    //add-migration "file-name" -context BuildDbContext 
    //
    add-migration AddModels-MemberandLoyalty -context BuildDbContext
    //to day
    remove-migration -context BuildDbContext
    
    $Env:ASPNETCORE_ENVIRONMENT = "Test"
    $Env:ASPNETCORE_ENVIRONMENT = "Development"
    $Env:ASPNETCORE_ENVIRONMENT = "UAT"
    $Env:ASPNETCORE_ENVIRONMENT = "Production"
    //
