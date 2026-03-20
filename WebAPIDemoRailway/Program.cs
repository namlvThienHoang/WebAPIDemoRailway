using Microsoft.EntityFrameworkCore;
using WebAPIDemoRailway.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var pgHost = Environment.GetEnvironmentVariable("PGHOST");
var pgPort = Environment.GetEnvironmentVariable("PGPORT");
var pgUser = Environment.GetEnvironmentVariable("PGUSER");
var pgPassword = Environment.GetEnvironmentVariable("PGPASSWORD");
var pgDatabase = Environment.GetEnvironmentVariable("PGDATABASE");

string connectionString;

if (!string.IsNullOrEmpty(pgHost) &&
    !string.IsNullOrEmpty(pgPort) &&
    !string.IsNullOrEmpty(pgUser) &&
    !string.IsNullOrEmpty(pgPassword) &&
    !string.IsNullOrEmpty(pgDatabase))
{
    // Build connection string from individual Railway Postgres variables
    connectionString = $"Host={pgHost};Port={pgPort};Username={pgUser};Password={pgPassword};Database={pgDatabase}";
}
else
{
    // Fall back to appsettings.json DefaultConnection for local development
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
}

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString,
        npg =>
        {
            npg.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            npg.SetPostgresVersion(15, 0);
        }));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
