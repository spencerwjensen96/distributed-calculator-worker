using distributed_calculator.Services;
using Microsoft.AspNetCore.Mvc;

namespace distributed_calculator.Controllers;


[ApiController]
[Route("create")]

public class CreateJobController : ControllerBase
{
    private readonly CreateJobService _createJobService;

    public CreateJobController(CreateJobService createJobService)
    {
        _createJobService = createJobService;
    }
    
    [HttpPost]
    public ActionResult CreateJob()
    {
        var response = _createJobService.CreateJob();
        return Ok(response);
    }
}