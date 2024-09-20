using System.Text.Json;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransactionHistoryAPI.Core.Interfaces.Services;
using TransactionHistoryAPI.Core.Models.RequestModels;

namespace TransactionHistoryAPI.Infrastructure.Services;

public class MessageProcessorServiceAsync
{
    private readonly ServiceBusClient _serviceBusClient;
    private readonly IServiceProvider _serviceProvider;
    private readonly ServiceBusProcessor _processor;
    private readonly string? _topicName;

    public MessageProcessorServiceAsync(IConfiguration configuration, ServiceBusClient serviceBusClient, IServiceProvider serviceProvider)
    {
        _serviceBusClient = serviceBusClient;
        _serviceProvider = serviceProvider;
        var connectionString = configuration["AzureServiceBus:ConnectionString"];
        _topicName = configuration["AzureServiceBus:TopicName"];
        var subscriptionName = configuration["AzureServiceBus:SubscriptionName"];

        var client = new ServiceBusClient(connectionString);
        _processor = client.CreateProcessor(_topicName, subscriptionName);
    }
    
    
    public async Task StartProcessingAsync()
    {
        Console.WriteLine("Listening to messages!!");
        
        _processor.ProcessMessageAsync += ProcessMessageHandler;
        _processor.ProcessErrorAsync += ProcessErrorHandler;

        await _processor.StartProcessingAsync();
    }
    
    private async Task ProcessMessageHandler(ProcessMessageEventArgs args)
    {
        var messageBody = args.Message.Body.ToString();

        if (messageBody.StartsWith("New Customer Added"))
        {
            var customerId = messageBody.Substring(messageBody.IndexOf(":") + 2);
            Console.WriteLine($"Customer Id: {customerId}");

            OrderRequestModel orderRequestModel = new OrderRequestModel
            {
                CustomerID = Convert.ToInt32(customerId),
                OrderDate = DateTime.Now,
                TotalAmount = 0
            };
            
            try
            {

                using (var scope = _serviceProvider.CreateScope())
                {
                    var orderServiceAsync = scope.ServiceProvider.GetRequiredService<IOrderServiceAsync>();
                    var transactionServiceAsync = scope.ServiceProvider.GetRequiredService<ITransactionServiceAsync>();
                    var orderId = await orderServiceAsync.Add(orderRequestModel);
                    if (orderId > 0)
                    {
                        TransactionRequestModel transactionRequestModel = new TransactionRequestModel
                        {
                            CustomerId = Convert.ToInt32(customerId),
                            OrderId = orderId,
                            TransactionDate = DateTime.Now,
                            Amount = orderRequestModel.TotalAmount
                        };
            
            
                        try
                        {
                            var transactionId = await transactionServiceAsync.Add(transactionRequestModel);
            
                            if (transactionId > 0)
                            {
                                ServiceBusSender sender = _serviceBusClient.CreateSender(_topicName);

                                var transactionDetails = new
                                    { TransactionId = transactionId, CustomerId = customerId, OrderId = orderId };

                                string transactionDetailsString = JsonSerializer.Serialize(transactionDetails);
                                
                                var message = new ServiceBusMessage($"Transaction Added: {transactionDetailsString}")
                                {
                                    CorrelationId = "PointsManagementService",
                                };
                                await sender.SendMessageAsync(message);
                                await args.CompleteMessageAsync(args.Message);
                            }
            
                            else
                            {
                                await orderServiceAsync.DeleteById(orderId);
                                Console.WriteLine("Failed to add the Transaction");
                            }
                        
                        }
                        catch (Exception ex)
                        {
                            await orderServiceAsync.DeleteById(orderId);
                            Console.WriteLine($"An error occurred: {ex.Message}");
                        }
                    }
                    else
                    {
                        // Send message to Customer service that Order Adding failed (but it is pointless here)
                        Console.WriteLine("Failed to add the order.");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                // Send message to Customer service that Order Adding failed (but it is pointless here)
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            
        }
    }
    
    private Task ProcessErrorHandler(ProcessErrorEventArgs args)
    {
        Console.WriteLine($"Error occurred: {args.Exception.Message}");
        return Task.CompletedTask;
    }
    
    public async Task StopProcessingAsync()
    {
        await _processor.StopProcessingAsync();
        await _processor.DisposeAsync();
    }
    
}