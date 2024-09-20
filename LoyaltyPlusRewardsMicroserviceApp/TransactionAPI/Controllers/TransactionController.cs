using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransactionHistoryAPI.Core.Interfaces.Services;
using TransactionHistoryAPI.Core.Models.RequestModels;

namespace TransactionHistoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionServiceAsync _transactionServiceAsync;

        public TransactionController(ITransactionServiceAsync transactionServiceAsync)
        {
            _transactionServiceAsync = transactionServiceAsync;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetTransactionAsync()
        {
            return Ok(await _transactionServiceAsync.GetAll());
        }
        
        
        [HttpPost]
        public async Task<IActionResult> PostTransactionAsync(TransactionRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _transactionServiceAsync.Add(model));
        }
        
        
    }
}
