using Azure.Messaging.ServiceBus;
using Microsoft.EntityFrameworkCore;
using TransactionHistoryAPI.Core.Interfaces.Repositories;
using TransactionHistoryAPI.Core.Interfaces.Services;
using TransactionHistoryAPI.Infrastructure.Data;
using TransactionHistoryAPI.Infrastructure.Repositories;
using TransactionHistoryAPI.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<TransactionDbContext>(option =>
{
    // option.UseSqlServer(builder.Configuration.GetConnectionString("TransactionDb"));
    option.UseSqlServer(Environment.GetEnvironmentVariable("TransactionDb"));
});

builder.Services.AddScoped<IOrderRepositoryAsync, OrderRepositoryAsync>();
builder.Services.AddScoped<IOrderServiceAsync, OrderServiceAsync>();
builder.Services.AddScoped<ITransactionServiceAsync, TransactionServiceAsync>();
builder.Services.AddScoped<ITransactionRepositoryAsync, TransactionRepositoryAsync>();

builder.Services.AddAutoMapper(typeof(Program));


builder.Services.AddSingleton(serviceProvider =>
{
    var configuration = serviceProvider.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetSection("AzureServiceBus:ConnectionString").Value;
    return new ServiceBusClient(connectionString);
});


builder.Services.AddSingleton<MessageProcessorServiceAsync>();


builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(p =>
    {
        p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});


var app = builder.Build();

var messageProcessor = app.Services.GetRequiredService<MessageProcessorServiceAsync>();
await messageProcessor.StartProcessingAsync();

app.Lifetime.ApplicationStopping.Register(async () =>
{
    await messageProcessor.StopProcessingAsync();
});



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();