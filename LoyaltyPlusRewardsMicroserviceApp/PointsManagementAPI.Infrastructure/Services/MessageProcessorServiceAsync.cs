using System.Text.Json;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;

namespace PointsAPI.Infrastructure.Services;

public class MessageProcessorServiceAsync
{
    
    private readonly ServiceBusClient _serviceBusClient;
    private readonly ServiceBusProcessor _processor;
    private readonly string? topicName;
    
    public MessageProcessorServiceAsync(IConfiguration configuration, ServiceBusClient serviceBusClient)
    {
        _serviceBusClient = serviceBusClient;
        var connectionString = configuration["AzureServiceBus:ConnectionString"];
        topicName = configuration["AzureServiceBus:TopicName"];
        var subscriptionName = configuration["AzureServiceBus:SubscriptionName"];

        var client = new ServiceBusClient(connectionString);
        _processor = client.CreateProcessor(topicName, subscriptionName);
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

        if (messageBody.StartsWith("Transaction Added"))
        {
            var transactionDetailsString = messageBody.Substring(messageBody.IndexOf(":") + 2);
            var transactionDetailsObject = JsonSerializer.Deserialize<Dictionary<string, object>>(transactionDetailsString);
            
            var transactionId = transactionDetailsObject!["TransactionId"].ToString();
            var customerId = transactionDetailsObject!["CustomerId"].ToString();
            var orderId = transactionDetailsObject!["OrderId"].ToString();

            Console.WriteLine($"Transaction Id: {transactionId}");
            Console.WriteLine($"Customer Id: {customerId}");
            Console.WriteLine($"Order Id: {orderId}");
    
            // Complete the message to remove it from the queue
            await args.CompleteMessageAsync(args.Message);
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