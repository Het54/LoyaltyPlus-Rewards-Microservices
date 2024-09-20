using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PointsAPI.Core.Entities;
using PointsAPI.Core.Interfaces.Services;

namespace PointsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointsBalanceController : ControllerBase
    {
        private readonly IPointsBalanceServiceAsync _pointsBalanceServiceAsync;

        public PointsBalanceController(IPointsBalanceServiceAsync pointsBalanceServiceAsync)
        {
            _pointsBalanceServiceAsync = pointsBalanceServiceAsync;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetPointsBalanceAsync()
        {
            return Ok(await _pointsBalanceServiceAsync.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> AddPointsBalanceAsync(PointsBalance model)
        {
            return Ok(await _pointsBalanceServiceAsync.Add(model));
        }
    }
}
