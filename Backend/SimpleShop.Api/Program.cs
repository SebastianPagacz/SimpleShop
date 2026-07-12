using Scalar.AspNetCore;
using SimpleShop.Application;
using SimpleShop.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

ApplicationDependencyInjection.AddMediatR(builder.Services);

InfrastructureDependencyInjection.AddDbContext(builder.Services);
InfrastructureDependencyInjection.AddQueryServices(builder.Services);
InfrastructureDependencyInjection.AddRepositories(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
