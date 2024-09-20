using Azure.Messaging.ServiceBus;
using CustomerRegistrationAndAuthAPI.Controllers;
using CustomerRegistrationAndAuthAPI.Core.Interfaces.Repositories;
using CustomerRegistrationAndAuthAPI.Core.Interfaces.Services;
using CustomerRegistrationAndAuthAPI.Infrastructure.Data;
using CustomerRegistrationAndAuthAPI.Infrastructure.Repositories;
using CustomerRegistrationAndAuthAPI.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CustomerRegistrationAndAuthDbContext>(option =>
{
    // option.UseSqlServer(builder.Configuration.GetConnectionString("CustomerDb"));
    option.UseSqlServer(Environment.GetEnvironmentVariable("CustomerDb"));
});

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<ICustomerRepositoryAsync, CustomerRepositoryAsync>();
builder.Services.AddScoped<ICustomerServiceAsync, CustomerServiceAsync>();
builder.Services.AddScoped<IRoleRepositoryAsync, RoleRepositoryAsync>();
builder.Services.AddScoped<IRoleServiceAsync, RoleServiceAsync>();
builder.Services.AddScoped<ICustomerRoleRepositoryAsync, CustomerRoleRepositoryAsync>();
builder.Services.AddScoped<ICustomerRoleServiceAsync, CustomerRoleServiceAsync>();

builder.Services.AddSingleton(serviceProvider =>
{
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetSection("AzureServiceBus:ConnectionString").Value;
    return new ServiceBusClient(connectionString);
});

builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(p =>
    {
        p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     
// }

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();