using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Domain.Repositories;
using MyApp.Infrastructure.Data;
using MyApp.Infrastructure.Repositories;
using MyApp.Application.Orders.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Controllers + FluentValidation
builder.Services.AddControllers()
    .AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssembly(Assembly.Load("MyApp.Application")));

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext: SQL Server reading DefaultConnection from appsettings.json
builder.Services.AddDbContext<AppDbContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                      sql => sql.MigrationsAssembly("MyApp.Infrastructure")));

// DI registrations
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("MyApp.Application")));
builder.Services.AddAutoMapper(typeof(Program).Assembly, Assembly.Load("MyApp.Application"));

var app = builder.Build();

// Aplicar migraciones automáticamente
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();