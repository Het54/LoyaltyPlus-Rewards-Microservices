using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PointsAPI.Core.Entities;
using PointsAPI.Core.Interfaces.Services;

namespace PointsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PointsTransactionController : ControllerBase
    {
        private readonly IPointsTransactionServiceAsync _pointsTransactionServiceAsync;

        public PointsTransactionController(IPointsTransactionServiceAsync pointsTransactionServiceAsync)
        {
            _pointsTransactionServiceAsync = pointsTransactionServiceAsync;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetPointsBalanceAsync()
        {
            return Ok(await _pointsTransactionServiceAsync.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> AddPointsBalanceAsync(PointsTransaction model)
        {
            return Ok(await _pointsTransactionServiceAsync.Add(model));
        }
    }
}
