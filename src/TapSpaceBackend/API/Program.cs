using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

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

app.Run();