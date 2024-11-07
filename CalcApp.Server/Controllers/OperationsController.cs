using CalcApp.Server.Models;
using CalcApp.Server.Requests;
using CalcApp.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalcApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OperationsController(OperationService operationService) : ControllerBase
    {
        [HttpPost("index")]
        public IActionResult PostOperationIndex([FromBody]OperationRequest request)
        {
            try
            {
                operationService.GetResult(request.FirstElement, request.SecondElement, request.CalculationMethod, request.Result);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
