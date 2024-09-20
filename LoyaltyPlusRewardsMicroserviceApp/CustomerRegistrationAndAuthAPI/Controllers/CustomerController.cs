using System.Text;
using System.Text.Json;
using CustomerRegistrationAndAuthAPI.Core.Entities;
using CustomerRegistrationAndAuthAPI.Core.Interfaces.Services;
using CustomerRegistrationAndAuthAPI.Core.Models.RequestModels;
using CustomerRegistrationAndAuthAPI.Core.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace CustomerRegistrationAndAuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServiceAsync _customerServiceAsync;

        public CustomerController(ICustomerServiceAsync customerServiceAsync)
        {
            _customerServiceAsync = customerServiceAsync;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerAsync()
        {
            return Ok(await _customerServiceAsync.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomerAsync(CustomerRequestModel model)
        {
            var id = await _customerServiceAsync.Add(model);
 
            CustomerResponseModelForUpdatingReplicatedDB customerModelForReplicatedDb =
                new CustomerResponseModelForUpdatingReplicatedDB
                {
                    Id = id,
                    Email = model.Email
                };
            
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("http://host.docker.internal:50124/");

                    var jsonContent = JsonSerializer.Serialize(customerModelForReplicatedDb);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    
                    HttpResponseMessage response = await httpClient.PostAsync("api/Customer",content);
                    
                    if (response.IsSuccessStatusCode)
                    {
                        return Ok(response.Content.ReadAsStringAsync().Result);
                    }
                    else
                    {
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
