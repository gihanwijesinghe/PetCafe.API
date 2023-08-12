using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PetCafe.API.Data;
using PetCafe.API.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<CafeDbContext>(item => item.UseSqlServer("string"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await MigrateAsync(app);
await SeedDataAsync(app);

app.Run();

static async Task MigrateAsync(IHost host)
{
    using var scope = host.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<CafeDbContext>();
    await db.Database.MigrateAsync();
}

static async Task SeedDataAsync(IHost host)
{
    var scope = host.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<CafeDbContext>();
    await DataSeeder.SeedCafes(context);
}