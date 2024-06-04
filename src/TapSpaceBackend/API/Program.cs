using API.Data;
using API.Extensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextFactory<ApplicationDbContext>(o
    => o.UseNpgsql(builder.Configuration["ConnectionStrings:DefaultConnection"]));

var app = builder.Build();

// Ensure the database is created and apply migrations
using (var scope = app.Services.CreateScope())
{
    var dbContextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<ApplicationDbContext>>();
    using (var context = dbContextFactory.CreateDbContext())
    {
        context.Database.Migrate();
    }
}

//app.UseLogging();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapGet("/getuserdata", () =>
    {
        return Results.StatusCode(StatusCodes.Status501NotImplemented);
    })
    .WithName("GetUserData")
    .WithOpenApi(operation => new OpenApiOperation
    {
        Summary = "Get user data",
        Description = "This endpoint is not implemented yet. It will return status 501.",
        Responses = new OpenApiResponses
        {
            {
                "501", new OpenApiResponse
                {
                    Description = "Not Implemented"
                }
            }
        }
    });

await app.SetupDatabaseAsync();

app.Run();