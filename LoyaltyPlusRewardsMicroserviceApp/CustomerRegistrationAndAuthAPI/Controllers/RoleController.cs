using CustomerRegistrationAndAuthAPI.Core.Interfaces.Services;
using CustomerRegistrationAndAuthAPI.Core.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerRegistrationAndAuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleServiceAsync _roleServiceAsync;

        public RoleController(IRoleServiceAsync roleServiceAsync)
        {
            _roleServiceAsync = roleServiceAsync;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetCustomerAsync()
        {
            return Ok(await _roleServiceAsync.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomerAsync(RoleRequestModel model)
        {
            return Ok(await _roleServiceAsync.Add(model));
        }
    }
}
