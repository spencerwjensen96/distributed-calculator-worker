using Microsoft.AspNetCore.Mvc;

namespace distributed_calculator.Controllers;

[ApiController]
[Route("health-check")]
public class HealthCheckController : ControllerBase
{
    [HttpGet]
    public ActionResult HealthCheck()
    {
        Console.WriteLine("Health Check");
        return Ok(new HealthCheckStatus()
        {
            Message = "Passed"
        });
    }
}

public class HealthCheckStatus : ActionResult
{
    public String? Message { get; set; }
}