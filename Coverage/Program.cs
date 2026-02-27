using Coverage.Core.Interfaces;
using Coverage.Data.Contexts;
using Coverage.Data.Seeders;
using Coverage.Data.Repositories.Interfaces;
using Coverage.Data.Repositories.Implementations;
// using Coverage.Services.BusinessLogic; // Commented out as PolicyService is not needed for seeding
// using Coverage.WebAPI.Middleware; // Commented out as middleware is not needed for seeding
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Configure JSON Configuration Sources (Gold-Standard)
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("Config/appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"Config/appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

//Dependency Injection setup
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPolicyRepository, PolicyRepository>();
builder.Services.AddScoped<IClaimRepository, ClaimRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IDecentralizedPoolRepository, DecentralizedPoolRepository>();


// Register Services
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Removed Middleware Configuration to focus only on seeding
// ConfigureMiddleware(app);

/// <summary>
/// Configures application services
/// </summary>
void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    // Database Context
    services.AddDbContext<CoverageDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

    // Commented out PolicyService registration
    // services.AddScoped<IPolicyService, PolicyService>();

    // Add API Controllers (No Views)
    // services.AddControllers(); // Commented out as it's not needed for seeding
}

// Seeding logic
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();

    try
    {
        var context = services.GetRequiredService<CoverageDbContext>();
        context.Database.Migrate(); // Applies pending migrations

        // Run the seeder unconditionally for testing
        DatabaseSeeder.Seed(context); // Call the seeding logic
        logger.LogInformation("Database seeding completed successfully.");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

// No need to run the application
// app.Run();
