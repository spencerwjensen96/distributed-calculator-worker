using System.Data;

namespace distributed_calculator.CreateJob;

public interface ICalculator
{
    Task<string> Calculate(string calculationString);
}

public class Calculator : ICalculator
{
    public Task<String> Calculate(string calculationString)
    {
        if (calculationString == null)
        {
            throw new NullReferenceException("Calculation cannot be null");
        }
        if(!calculationString.StartsWith("CALCULATE: "))
        {
            throw new Exception("Unknown calculation command. Command: " + calculationString);
        }

        var expression = calculationString.Substring("CALCULATE: ".Length, calculationString.Length - "CALCULATE: ".Length);
        
        var dt = new DataTable();
        var result = dt.Compute(expression, "").ToString();
        if (result == null)
        {
            throw new Exception("Something went wrong and the result is null.");
        }
        return Task.FromResult(result);
    }
}