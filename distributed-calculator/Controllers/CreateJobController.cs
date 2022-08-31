using distributed_calculator.CreateJob;
using Microsoft.AspNetCore.Mvc;

namespace distributed_calculator.Controllers;

[ApiController]
[Route("createJob")]

public class CreateJobController : ControllerBase
{
    private readonly ICreateJobService _createJobService;

    public CreateJobController(ICreateJobService createJobService)
    {
        _createJobService = createJobService;
    }
    
    [HttpPost]
    public ActionResult CreateJob([FromBody] CreateJobRequest createJobRequest)
    {
        Console.WriteLine("Creating Job...");
        var response = _createJobService.CreateJob(createJobRequest);
        return Ok(response);
    }
}

public class CreateJobRequest
{
    public CreateJobRequest(Guid jobId, string calculation)
    {
        JobId = jobId;
        Calculation = calculation;
    }

    public Guid JobId { get; set; }
    public string Calculation { get; set; }
}

public class CreateJobResponse
{
    public CreateJobResponse(Guid jobId, string result)
    {
        JobId = jobId;
        Result = result;
    }

    public Guid JobId { get; set; }
    public string Result { get; set; }
}