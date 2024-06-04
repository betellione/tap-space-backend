using API.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace API.Extensions;

public static class ApplicationExtensions
{
    public static IApplicationBuilder UseLogging(this IApplicationBuilder app)
    {
        app.UseSerilogRequestLogging();
        return app;
    }
    
    public static async Task<IApplicationBuilder> SetupDatabaseAsync(this WebApplication app)
    {
        try
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await dbContext.Database.MigrateAsync();

            return app;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Cannot setup database: {e.Message}");
            throw;
        }
    }
}