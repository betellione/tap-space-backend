using API.Data;
using API.Extensions;
using Microsoft.EntityFrameworkCore;
// TODO Сделать комментарии в коде
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContextFactory<ApplicationDbContext>(o
    => o.UseNpgsql(builder.Configuration["ConnectionStrings:DefaultConnection"]));

var app = builder.Build();

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

await app.SetupDatabaseAsync();

app.Run();