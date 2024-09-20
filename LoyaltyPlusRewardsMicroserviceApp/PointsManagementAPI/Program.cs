using Azure.Messaging.ServiceBus;
using Microsoft.EntityFrameworkCore;
using PointsAPI.Core.Interfaces.Repositories;
using PointsAPI.Core.Interfaces.Services;
using PointsAPI.Infrastructure.Data;
using PointsAPI.Infrastructure.Repositories;
using PointsAPI.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PointsManagementDbContext>(option =>
{
    // option.UseSqlServer(builder.Configuration.GetConnectionString("PointsManagementDb"));
    option.UseSqlServer(Environment.GetEnvironmentVariable("PointsManagementDb"));
});

builder.Services.AddScoped<IPointsBalanceRepositoryAsync, PointsBalanceRepositoryAsync>();
builder.Services.AddScoped<IPointsBalanceServiceAsync, PointsBalanceServiceAsync>();
builder.Services.AddScoped<IPointsTransactionRepositoryAsync, PointsTransactionRepositoryAsync>();
builder.Services.AddScoped<IPointsTransactionServiceAsync, PointsTransactionServiceAsync>();
builder.Services.AddScoped<ICustomerRepositoryAsync, CustomerRepositoryAsync>();
builder.Services.AddScoped<ICustomerServiceAsync, CustomerServiceAsync>();

builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(p =>
    {
        p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});


builder.Services.AddSingleton(serviceProvider =>
{
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetSection("AzureServiceBus:ConnectionString").Value;
    return new ServiceBusClient(connectionString);
});

builder.Services.AddSingleton<MessageProcessorServiceAsync>();


var app = builder.Build();


var messageProcessor = app.Services.GetRequiredService<MessageProcessorServiceAsync>();
await messageProcessor.StartProcessingAsync();

app.Lifetime.ApplicationStopping.Register(async () =>
{
    await messageProcessor.StopProcessingAsync();
});



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