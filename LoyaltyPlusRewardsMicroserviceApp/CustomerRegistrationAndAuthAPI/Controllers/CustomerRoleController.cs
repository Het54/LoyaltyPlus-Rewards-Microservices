using CustomerRegistrationAndAuthAPI.Core.Interfaces.Services;
using CustomerRegistrationAndAuthAPI.Core.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerRegistrationAndAuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerRoleController : ControllerBase
    {
        private readonly ICustomerRoleServiceAsync _customerRoleServiceAsync;


        public CustomerRoleController(ICustomerRoleServiceAsync customerRoleServiceAsync)
        {
            _customerRoleServiceAsync = customerRoleServiceAsync;
        }
        
        [HttpGet("GetRoles")]
        public async Task<IActionResult> GetCustomersAsync()
        {
            return Ok(await _customerRoleServiceAsync.GetAll());
        }
        
        [HttpGet("GetCustomersWithRoles")]
        public async Task<IActionResult> GetCustomersWithRolesAsync()
        {
            return Ok(await _customerRoleServiceAsync.GetAllCustomerWithRolesAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomerAsync(CustomerRoleRequestModel model)
        {
            return Ok(await _customerRoleServiceAsync.Add(model));
        }
    }
}
