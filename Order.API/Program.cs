using Microsoft.EntityFrameworkCore;
using Order.Infrastructure.Persistence;
using Order.Application.Contracts;
using Order.Infrastructure.Repositories;
using Order.Application.Commands;
using Order.Application.Validators;
using Order.Application.Profiles;
using FluentValidation;
using MediatR;
using AutoMapper;
using Order.Infrastructure.ExternalServices;
using Order.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add Controllers
builder.Services.AddControllers();

// DbContext 
builder.Services.AddDbContext<OrderDbContext>(options =>
    options.UseSqlServer(
        "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OrderDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
    )
);

// Repositories
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// HttpClient Product API Logger
builder.Services.AddHttpClient("ProductAPI", client =>
{
    client.BaseAddress = new Uri("http://localhost:5155/");
});

builder.Services.AddScoped<IProductRepository>(provider =>
{
    var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
    var client = httpClientFactory.CreateClient("ProductAPI");
    var logger = provider.GetRequiredService<ILogger<ProductRepositoryHttp>>();
    return new ProductRepositoryHttp(client, logger);
});


// MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateOrderCommand).Assembly));

// AutoMapper
builder.Services.AddSingleton(provider => new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new OrderMappingProfile());
}).CreateMapper());

// FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<CreateOrderCommandValidator>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Build
var app = builder.Build();

// Swagger Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middleware Pipeline
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

// Migrations 
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<OrderDbContext>();
    db.Database.Migrate();
}

app.Run();
