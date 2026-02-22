using InventoryManagementSystem.API.ExceptionHandlers;
using InventoryManagementSystem.Application.Contracts.Services;
using InventoryManagementSystem.Infrastructure.Data.Context;
using InventoryManagementSystem.Shared.Extensions;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddCoreServices(typeof(IApplicationAssemblyMarker).Assembly);
builder.Services.AddInfrastructureServices<InventoryManagementSystemDbContext>(builder.Configuration);
builder.Services.AddSharedOpenApiDocumentation();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();
app.UseSharedOpenApiDocumentation();

app.Run();
