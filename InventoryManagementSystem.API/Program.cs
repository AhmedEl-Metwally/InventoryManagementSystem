using InventoryManagementSystem.Infrastructure.Data.Context;
using InventoryManagementSystem.Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSharedOpenApiDocumentation();
builder.Services.AddInfrastructureServices<InventoryManagementSystemDbContext>(builder.Configuration);
builder.Services.AddCoreServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSharedOpenApiDocumentation();    

app.Run();
