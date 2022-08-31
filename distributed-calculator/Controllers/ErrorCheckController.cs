using distributed_calculator.ErrorCheck;
using Microsoft.AspNetCore.Mvc;

namespace distributed_calculator.Controllers;

[ApiController]
[Route("errorCheck")]

public class ErrorCheckController : ControllerBase
{
    private readonly IErrorCheckService _errorCheckService;

    public ErrorCheckController(IErrorCheckService errorCheckService)
    {
        _errorCheckService = errorCheckService;
    }
    
    [HttpPost]
    public ActionResult ErrorCheck([FromBody] ErrorCheckRequest errorCheckRequest)
    {
        Console.WriteLine("Error Detected...");
        var result = _errorCheckService.Execute(errorCheckRequest);
        return Ok();
    }
}

public class ErrorCheckRequest
{
    public ErrorCheckRequest(Guid jobId, string errorMessage)
    {
        JobId = jobId;
        ErrorMessage = errorMessage;
    }

    public Guid JobId { get; set; }
    public string ErrorMessage { get; set; }
}