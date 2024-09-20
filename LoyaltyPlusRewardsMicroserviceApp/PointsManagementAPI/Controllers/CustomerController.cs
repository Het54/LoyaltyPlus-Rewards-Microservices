using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PointsAPI.Core.Entities;
using PointsAPI.Core.Interfaces.Services;

namespace PointsAPI.Controllers
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
        public async Task<IActionResult> AddCustomerAsync(Customer model)
        {
            return Ok(await _customerServiceAsync.Add(model));
        }
    }
}
