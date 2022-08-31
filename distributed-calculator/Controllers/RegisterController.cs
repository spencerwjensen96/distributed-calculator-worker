using distributed_calculator.Registration;
using Microsoft.AspNetCore.Mvc;

namespace distributed_calculator.Controllers;

[ApiController]
[Route("register")]
public class RegisterController : ControllerBase
{
    private readonly IRegistrationService _registrationService;

    public RegisterController(IRegistrationService registrationService)
    {
        _registrationService = registrationService;
    }

    [HttpPost]
    public async Task<ActionResult> Register([FromBody] RegistrationRequest registrationRequest)
    {
        Console.WriteLine("Registering...");
        var result = await _registrationService.RegisterAsync(registrationRequest);
        return Ok(result);
    }
}

public class RegistrationRequest
{
    public RegistrationRequest(string url, Guid workerId, string teamName, string createJobEndpoint, string errorCheckEndpoint)
    {
        URL = url;
        WorkerId = workerId;
        TeamName = teamName;
        CreateJobEndpoint = createJobEndpoint;
        ErrorCheckEndpoint = errorCheckEndpoint;
    }

    public string URL { get; set; }
    public Guid WorkerId { get; set; }
    public string TeamName { get; set; }
    public string CreateJobEndpoint { get; set; }
    public string ErrorCheckEndpoint { get; set; }
}

public class RegistrationResult
{
    public RegistrationResult(string result)
    {
        Result = result;
    }

    public string Result { get; set; }
}