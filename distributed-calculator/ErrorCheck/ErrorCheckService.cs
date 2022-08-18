using distributed_calculator.Controllers;

namespace distributed_calculator.ErrorCheck;

public interface IErrorCheckService
{
    Task Execute(ErrorCheckRequest errorCheckRequest);
}

public class ErrorCheckService : IErrorCheckService
{
    public async Task Execute(ErrorCheckRequest errorCheckRequest)
    {
        
    }
}