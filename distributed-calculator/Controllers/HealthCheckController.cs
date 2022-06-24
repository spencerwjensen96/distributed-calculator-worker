using Microsoft.AspNetCore.Mvc;

namespace distributed_calculator.Controllers;

[ApiController]
[Route("health-check")]

public class HealthCheckController : ControllerBase
{
    [HttpPost]
    public ActionResult HealthCheck()
    {
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