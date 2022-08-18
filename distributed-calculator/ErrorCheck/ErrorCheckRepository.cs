namespace distributed_calculator.ErrorCheck;

public interface IErrorCheckRepository
{
    Task Execute();
}

public class ErrorCheckRepository : IErrorCheckRepository
{
    public Task Execute()
    {
        return Task.CompletedTask;
    }
}