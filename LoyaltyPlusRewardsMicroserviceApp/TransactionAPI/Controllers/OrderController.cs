using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TransactionHistoryAPI.Core.Interfaces.Services;
using TransactionHistoryAPI.Core.Models.RequestModels;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace TransactionHistoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServiceAsync _orderServiceAsync;

        public OrderController(IOrderServiceAsync orderServiceAsync)
        {
            _orderServiceAsync = orderServiceAsync;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetOrderAsync()
        {
            return Ok(await _orderServiceAsync.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> PostOrderAsync(OrderRequestModel model)
        {
            var orderId = await _orderServiceAsync.Add(model);
            TransactionRequestModel transactionRequestModel = new TransactionRequestModel
            {
                CustomerId = model.CustomerID,
                OrderId = orderId,
                TransactionDate = DateTime.Now,
                Amount = model.TotalAmount
            };
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {

                    var jsonContent = JsonConvert.SerializeObject(transactionRequestModel);
                    var s = jsonContent.ToString();
                    Console.WriteLine($"JsonContent: {s}");
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    
                    HttpResponseMessage response = await httpClient.PostAsync("http://host.docker.internal:50125/api/Transaction",content);
                    
                    if (response.IsSuccessStatusCode)
                    {
                        return Ok(response.ToString());
                    }
                    else
                    {
                        await _orderServiceAsync.DeleteById(orderId);
                        return StatusCode((int)response.StatusCode, "Error from external service: " + response.ReasonPhrase);
                    }
                }
            }
            catch (HttpRequestException httpRequestEx)
            {
                // Handle network or connection issues
                return StatusCode(500, $"Request error: {httpRequestEx.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        
    }
}
