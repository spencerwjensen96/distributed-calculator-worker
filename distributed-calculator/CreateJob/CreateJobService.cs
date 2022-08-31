using distributed_calculator.Controllers;
using distributed_calculator.Services;

namespace distributed_calculator.CreateJob;

public interface ICreateJobService
{
    Task<CreateJobResponse> CreateJob(CreateJobRequest createJobRequest);
}

public class CreateJobService : ICreateJobService
{
    private readonly ICalculator _calculator;

    public CreateJobService(ICalculator calculator)
    {
        _calculator = calculator;
    }
    public async Task<CreateJobResponse> CreateJob(CreateJobRequest createJobRequest)
    {
        var calculationResult = await _calculator.Calculate(createJobRequest.Calculation);
        var response = new CreateJobResponse(createJobRequest.JobId, calculationResult);
        return response;
    }
}
